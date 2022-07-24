﻿using Authzed.Api.V1;
using Google.Protobuf.Collections;
using SpiceDB.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using SpiceDB.Core.Types;

namespace SpiceDB.UI
{
    public class SpiceDBService
    {
        public Dictionary<string, Core.Types.ResultList<Relationship>> AllData = new();
        Core.Core _core;
        public IEnumerable<SchemaEntity> SchemaEntities;

        public SpiceDBService()
        {
            //TODO: user serverAddress, token
            //    _service = new AuthorizationDB(serverAddress, token, null);
        }

        private static readonly SpiceDBService instance = new SpiceDBService();

        public static SpiceDBService Instance
        {
            get
            {
                return instance;
            }
        }


        public async Task Load(string serverAddress, string token)
        {
            _core = new Core.Core(serverAddress, token);

            SchemaEntities = SchemaParser.Parse(_core.ReadSchema());

            foreach (var entity in SchemaEntities)
            {
                var result = await _core.ReadRelationships(entity.ResourceType);
                AllData[entity.ResourceType] = result;
            }
        }

        public bool IsDataLoadedSucessfully()
        {
            //TODO:work on this
            return true;
        }

        public void AddRelation(string resourceType, string resourceId, string relation,
               string subjectType, string subjectId, string optionalSubjectRelation = "")
        {
            _core.UpdateRelationship(resourceType, resourceId, relation, subjectType, subjectId, optionalSubjectRelation);
        }

        public void DeleteRelation(string resourceType, string resourceId, string relation,
             string subjectType, string subjectId, string optionalSubjectRelation = "")
        {
            _core.UpdateRelationship(resourceType, resourceId, relation, subjectType, subjectId, optionalSubjectRelation, RelationshipUpdate.Types.Operation.Delete);
        }

        public async Task<List<string>> GetResourcePermissions(string resourceType, string permission, string subjectType, string subjectId, ZedToken zedToken = null, CacheFreshness cacheFreshness = CacheFreshness.AnyFreshness)
        {
            return await _core.GetResourcePermissions(resourceType, permission, subjectType, subjectId, zedToken);
        }


        public SchemaImport ImportSchema(string filePath)
        {
            var deserializer = new DeserializerBuilder()
             .WithNamingConvention(CamelCaseNamingConvention.Instance)
             .Build();

            string schema = System.IO.File.ReadAllText(filePath);

            SchemaImport yamlImport = deserializer.Deserialize<SchemaImport>(schema);

            if (!string.IsNullOrEmpty(yamlImport.schema))
            {
                _core.WriteSchema(yamlImport.schema);
            }

            ImportRelationships(yamlImport.relationships);

            return yamlImport;
        }

        private WriteRelationshipsResponse ImportRelationships(string content)
        {
            // Read the file as one string.
            RelationshipUpdate.Types.Operation operation = RelationshipUpdate.Types.Operation.Touch;
            RepeatedField<RelationshipUpdate> updateCollection = new RepeatedField<RelationshipUpdate>();
            RelationshipUpdate updateItem;

            var lines = content.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                string[] cols = System.Text.RegularExpressions.Regex.Split(line.Trim(), ":|@|#");//refer to authzed docs for separator meanings
                if (cols.Length == 5)
                {
                    updateItem = Core.Core.GetRelationshipUpdate(cols[0], cols[1], cols[2], cols[3], cols[4], "", operation);
                    Core.Core.UpdateRelationships(ref updateCollection, updateItem);
                }
                else if (cols.Length == 6)//contain an additional column of optional subject relation
                {
                    updateItem = Core.Core.GetRelationshipUpdate(cols[0], cols[1], cols[2], cols[3], cols[4], cols[5], operation);
                    Core.Core.UpdateRelationships(ref updateCollection, updateItem);
                }
            }

            return _core.WriteRelationships(ref updateCollection);
        }

    }

   
}
