using CHC.Domain.Common;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.Material;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.InteriorDetail
{
    public class InteriorDetailDto : BaseEntity
    {
        public double TotalPrice { get; set; } = 0;
        public virtual InteriorDto Interior { get; set; } = null!;
        public virtual ICollection<MaterialDto> Materials { get; set; } = new List<MaterialDto>();
    }
}
