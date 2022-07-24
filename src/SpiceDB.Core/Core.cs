using Authzed.Api.V1;
using Google.Protobuf.Collections;
using Grpc.Core;
using Grpc.Net.Client;
using SpiceDB.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceDB.Core
{
    public class Core
    {
        private PermissionsService.PermissionsServiceClient _acl;
        private SchemaService.SchemaServiceClient _schema;
        private CallOptions _callOptions;
        private Metadata _headers;

        string _serverAddress = "http://localhost:50051";
        string _presharedKey = "spicedb_token";

        public Core(string serverAddress, string presharedKey)
        {
            _serverAddress = serverAddress;
            _presharedKey= presharedKey;
            Start();
        }
        private void Start()
        {
            var channel = CreateAuthenticatedChannelAsync(_serverAddress);

            //initializes new clients for interacting with Authzed.
            _acl = new PermissionsService.PermissionsServiceClient(channel.Result);
            _schema = new SchemaService.SchemaServiceClient(channel.Result);

            _headers = new Metadata();
            _headers.Add("Authorization", $"Bearer {_presharedKey}");
            if (_serverAddress.StartsWith("http:"))
            {
                _callOptions = new CallOptions(_headers);
            }
            else if (_serverAddress.StartsWith("https:"))
            {
                _callOptions = new CallOptions();
            }
            else
            {
                throw new ArgumentException("Expecting http or https in the authzed endpoint.");
            }

        }

        public async Task<List<string>> GetResourcePermissions(string resourceType, string permission, string subjectType, string subjectId, ZedToken zedToken = null,CacheFreshness cacheFreshness = CacheFreshness.AnyFreshness)
        {
            LookupResourcesRequest req = new LookupResourcesRequest
            {
                Consistency = new Consistency { MinimizeLatency = true, AtExactSnapshot = zedToken },
                Permission = permission,
                ResourceObjectType = resourceType,
                Subject = new SubjectReference { Object = new ObjectReference { ObjectType = subjectType, ObjectId = subjectId } }
            };

            if (cacheFreshness == CacheFreshness.AtLeastAsFreshAs)
            {
                req.Consistency.AtLeastAsFresh = zedToken;
            }
            else if (cacheFreshness == CacheFreshness.MustRefresh || zedToken == null)
            {
                req.Consistency.FullyConsistent = true;
            }

            //Server streaming call, reads messages streamed from the service
            var _call = _acl.LookupResources(req, _callOptions);

            var list = new List<string>();

            //The IAsyncStreamReader<T>.ReadAllAsync() extension method reads all messages from the response stream
            await foreach (var resp in _call.ResponseStream.ReadAllAsync())
            {
                list.Add(resp.ResourceObjectId);
            }
            return list;
        }

        public async Task<Types.ResultList<Relationship>> ReadRelationships(string resourceType, string optionalResourceId = "",
         string optionalRelation = "", string optionalSubjectType = "", string optionalSubjectId = "", string optionalSubjectRelation = "",
         ZedToken zedToken = null,
         Types.CacheFreshness cacheFreshness = Types.CacheFreshness.AnyFreshness)
        {
            ReadRelationshipsRequest req = new ReadRelationshipsRequest()
            {
                Consistency = new Consistency { MinimizeLatency = true, AtExactSnapshot = zedToken },
                RelationshipFilter = new RelationshipFilter
                {
                    ResourceType = resourceType,
                    OptionalRelation = optionalRelation,
                    OptionalResourceId = optionalResourceId
                }
            };
            if (!String.IsNullOrEmpty(optionalSubjectType))
            {
                req.RelationshipFilter.OptionalSubjectFilter = new SubjectFilter() { SubjectType = optionalSubjectType, OptionalSubjectId = optionalSubjectId };
                if (!String.IsNullOrEmpty(optionalSubjectRelation))
                {
                    req.RelationshipFilter.OptionalSubjectFilter.OptionalRelation = new SubjectFilter.Types.RelationFilter() { Relation = optionalSubjectRelation };
                }
            }
            if (cacheFreshness == Types.CacheFreshness.AtLeastAsFreshAs)
            {
                req.Consistency.AtLeastAsFresh = zedToken;
            }
            else if (cacheFreshness == Types.CacheFreshness.MustRefresh || zedToken == null)
            {
                req.Consistency.FullyConsistent = true;
            }
            var _call = _acl.ReadRelationships(req, _callOptions);
            List<Relationship> _list = new List<Relationship>();

            await foreach (var resp in _call.ResponseStream.ReadAllAsync())
            {
                _list.Add(resp.Relationship);
            }

            return new Types.ResultList<Relationship> { Data = _list };
        }

        public string ReadSchema()
        {
            ReadSchemaRequest req = new ReadSchemaRequest();
            ReadSchemaResponse resp;
            resp = _schema.ReadSchema(req, _callOptions);
            return resp.SchemaText;
        }

        public WriteSchemaResponse WriteSchema(string schema)
        {
            WriteSchemaRequest req = new WriteSchemaRequest
            {
                Schema = schema
            };
            return _schema.WriteSchema(req, _callOptions);
        }

        private async Task<ChannelBase> CreateAuthenticatedChannelAsync(string address)
        {
            var token = await GetTokenAsync();
            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(token))
                {
                    metadata.Add("Authorization", $"Bearer {token}");
                }
                return Task.CompletedTask;
            });

            // SslCredentials is used here because this channel is using TLS.
            // CallCredentials can't be used with ChannelCredentials.Insecure on non-TLS channels.
            ChannelBase channel;
            if (address.StartsWith("http:"))
            {
                Uri baseUri = new Uri(address);
                channel = new Grpc.Core.Channel(baseUri.Host, baseUri.Port, ChannelCredentials.Insecure);
            }
            else
            {
                channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
                {
                    //HttpHandler = handler,
                    Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
                });
            }
            return channel;
        }

        private Task<string> GetTokenAsync()
        {
            return Task.FromResult(_presharedKey);
        }

        public static Boolean UpdateRelationships(ref RepeatedField<RelationshipUpdate> updateCollection,
      RelationshipUpdate updateItem, bool AddOrDelete = true)
        {
            if (AddOrDelete)
            {
                updateCollection.Add(updateItem);
                return true;
            }
            else
            {
                return updateCollection.Remove(updateItem);
            }
        }

        public static RelationshipUpdate GetRelationshipUpdate(string resourceType, string resourceId,
               string relation, string subjectType, string subjectId, string optionalSubjectRelation = "",
               RelationshipUpdate.Types.Operation operation = RelationshipUpdate.Types.Operation.Touch)
        {
            return new RelationshipUpdate
            {
                Operation = operation,
                Relationship = new Relationship()
                {
                    Resource = new ObjectReference { ObjectType = resourceType, ObjectId = resourceId },
                    Relation = relation,
                    Subject = new SubjectReference { Object = new ObjectReference { ObjectType = subjectType, ObjectId = subjectId }, OptionalRelation = optionalSubjectRelation },
                }
            };
        }


        public WriteRelationshipsResponse WriteRelationships(ref RepeatedField<RelationshipUpdate> updateCollection)
        {
            WriteRelationshipsRequest req = new WriteRelationshipsRequest() { Updates = { updateCollection } }; //Wrapping the object in a curly bracket works!
            return _acl.WriteRelationships(req, _callOptions);
        }



        public ZedToken UpdateRelationship(string resourceType, string resourceId, string relation,
               string subjectType, string subjectId, string optionalSubjectRelation = "",
              RelationshipUpdate.Types.Operation operation = RelationshipUpdate.Types.Operation.Touch)
        {

           return UpdateRelationships(resourceType, resourceId, new[] { relation }, subjectType, subjectId, optionalSubjectRelation, operation);
        }

        public ZedToken UpdateRelationships(string resourceType, string resourceId, IEnumerable<string> relations, 
                string subjectType, string subjectId, string optionalSubjectRelation="",
               RelationshipUpdate.Types.Operation operation = RelationshipUpdate.Types.Operation.Touch)
        {

            RelationshipUpdate updateItem;
            RepeatedField<RelationshipUpdate> updateCollection = new RepeatedField<RelationshipUpdate>();

            foreach (var relation in relations)
            {
                updateItem = GetRelationshipUpdate(resourceType, resourceId, relation.ToLowerInvariant(), subjectType, subjectId, optionalSubjectRelation, operation);
                UpdateRelationships(ref updateCollection, updateItem);
            }

            WriteRelationshipsResponse resp = WriteRelationships(ref updateCollection);
            return resp.WrittenAt;
        }
    }

    
}
