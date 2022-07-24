using Authzed.Api.V1;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SpiceDBProtoTest
{
    public class Auth
    {
        Core _core = new Core();

        public async Task Test()
        {
            try
            {
                var entities = SchemaParser.Parse(_core.ReadSchema());

                foreach (var entity in entities)
                {
                    var result = await _core.ReadRelationships(entity.ResourceType);
                }
            }
            catch (Exception ex)
            {

                var tt = ex;
            }

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
                    updateItem = Core.GetRelationshipUpdate(cols[0], cols[1], cols[2], cols[3], cols[4], "", operation);
                    Core.UpdateRelationships(ref updateCollection, updateItem);
                }
                else if (cols.Length == 6)//contain an additional column of optional subject relation
                {
                    updateItem = Core.GetRelationshipUpdate(cols[0], cols[1], cols[2], cols[3], cols[4], cols[5], operation);
                    Core.UpdateRelationships(ref updateCollection, updateItem);
                }
            }

            return _core.WriteRelationships(ref updateCollection);
        }
    }

    public class SchemaImport
    {
        public string schema { get; set; }
        public string relationships { get; set; }
        public Dictionary<string, List<string>> Assertions { get; set; }
        public Dictionary<string, List<string>> Validation { get; set; }
    }
}
