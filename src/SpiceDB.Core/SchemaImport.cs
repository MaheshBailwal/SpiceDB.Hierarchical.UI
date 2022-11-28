namespace SpiceDB.Core.Types
{
    public class SchemaImport123
    {
        public string schema { get; set; }
        public string relationships { get; set; }
        public Dictionary<string, List<string>> Assertions { get; set; }
        public Dictionary<string, List<string>> Validation { get; set; }
    }
}
