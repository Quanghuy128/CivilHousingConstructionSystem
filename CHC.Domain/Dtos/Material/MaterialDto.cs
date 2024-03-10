using CHC.Domain.Common;
using CHC.Domain.Enums;

namespace CHC.Domain.Dtos.Material
{
    public class MaterialDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public MaterialTag Tag { get; set; } = MaterialTag.Others;
    }
}
