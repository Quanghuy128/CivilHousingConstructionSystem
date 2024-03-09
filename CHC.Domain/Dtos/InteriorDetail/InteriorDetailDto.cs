using CHC.Domain.Common;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.Material;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.InteriorDetail
{
    public class InteriorDetailDto : BaseEntity
    {
        public int Quantity { get; set; } = 0;
        public Guid InteriorId { get; set; }
        public virtual InteriorViewModel Interior { get; set; } = null!;
        public Guid MaterialId { get; set; }
        public virtual MaterialViewModel Material { get; set; } = null!;
    }
}
