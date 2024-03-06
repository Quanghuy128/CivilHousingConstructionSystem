using CHC.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.Material
{
    public class MaterialDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
