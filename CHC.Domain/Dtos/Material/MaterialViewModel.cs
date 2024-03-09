using CHC.Domain.Enums;

namespace CHC.Domain.Dtos.Material
{
    public class MaterialViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public MaterialTag Tag { get; set; } = MaterialTag.Others;
    }
}
