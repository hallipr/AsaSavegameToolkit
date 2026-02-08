namespace AsaSavegameToolkit.Serialization
{
    /// <summary>
    /// Represents a generic type in UE5.5 format (SaveVersion 14+).
    /// Generic types can have subtypes, creating a recursive structure.
    /// For example: ArrayProperty[StructProperty[HibernationCountInfo[/Script/ShooterGame]]]
    /// </summary>
    public class AsaGenericType
    {
        public AsaName TypeName { get; init; }
        public List<AsaGenericType> SubTypes { get; init; }

        public AsaGenericType()
        {
            TypeName = AsaName.NameNone;
            SubTypes = [];
        }

        public AsaGenericType(AsaName typeName, List<AsaGenericType> subTypes)
        {
            TypeName = typeName;
            SubTypes = subTypes;
        }

        public static bool TryRead(AsaArchive archive, out AsaGenericType? result)
        {
            return TryReadGenericTypes(archive, 1, out var results) && results.Count > 0
                ? (result = results[0]) != null
                : (result = null) == null;
        }

        public static bool TryReadGenericTypes(AsaArchive archive, int count, out List<AsaGenericType> results)
        {
            results = [];

            try
            {
                for (int i = 0; i < count; i++)
                {
                    if (!archive.TryReadName("generic type", out var typeName))
                    {
                        return false;
                    }

                    int subTypeCount = archive.ReadInt32("subtype count");
                    var subTypes = new List<AsaGenericType>();

                    if (subTypeCount > 0)
                    {
                        if (!TryReadGenericTypes(archive, subTypeCount, out subTypes))
                        {
                            return false;
                        }
                    }

                    results.Add(new AsaGenericType(typeName, subTypes));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            if (SubTypes.Count == 0)
            {
                return TypeName.Name;
            }

            var subTypeStrings = string.Join(", ", SubTypes.Select(st => st.ToString()));
            return $"{TypeName.Name}[{subTypeStrings}]";
        }
    }
}
