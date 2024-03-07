using CHC.Domain.Common;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.Material;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.InteriorDetail
{
    public class InteriorDetailDto : BaseEntity
    {
        public int Quantity { get; set; } = 0;
        public virtual MaterialDto Material { get; set; } = null!;
    }
}
