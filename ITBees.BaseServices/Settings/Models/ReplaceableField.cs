namespace ITBees.BaseServices.Settings.Models
{
    public class ReplaceableField
    {
        public ReplaceableField(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}