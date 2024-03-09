using CHC.Domain.Dtos.Material;

namespace CHC.Domain.Dtos.Interior
{
    public class InteriorViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double TotalPrice { get; set; } = 0;
    }
}
