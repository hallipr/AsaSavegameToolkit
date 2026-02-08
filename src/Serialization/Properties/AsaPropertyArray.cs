namespace AsaSavegameToolkit.Serialization.Properties
{
    public class AsaPropertyArray
    {
        public List<dynamic> Value { get; }
        public string Name { get; }
        public long FileOffset { get; init; }
        public long FileLength { get; init; }

        public AsaPropertyArray(string name, List<dynamic> items)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = items ?? throw new ArgumentNullException(nameof(items));
        }
    }
}
