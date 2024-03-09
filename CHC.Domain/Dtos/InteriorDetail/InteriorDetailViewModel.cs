using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.Material;

namespace CHC.Domain.Dtos.InteriorDetail
{
    public class InteriorDetailViewModel
    {
        public int Quantity { get; set; } = 0;
        public Guid InteriorId { get; set; }
        public Guid MaterialId { get; set; }
    }
}
