using CHC.Domain.Enums;

namespace CHC.Presentation.Extensions
{
    public static class DictionaryHandler
    {
        public static string GetIconFromMaterialTag(MaterialTag tag)
        {
            Dictionary<MaterialTag, string> tags = new Dictionary<MaterialTag, string>()
            {
                { MaterialTag.Bed, "fa-bed"},
                { MaterialTag.Bath, "fa-bath"},
            };
            return tags.GetValueOrDefault<MaterialTag, string>(tag)!;
        }
    }
}
