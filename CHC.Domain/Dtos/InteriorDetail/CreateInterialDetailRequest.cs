using CHC.Domain.Dtos.Interior;

namespace CHC.Domain.Dtos.InteriorDetail
{
    public class CreateInterialDetailRequest
    {
        public int Quantity { get; set; } = 0;
        public Guid InteriorId { get; set; }
        public Guid MaterialId { get; set; }
    }
}
