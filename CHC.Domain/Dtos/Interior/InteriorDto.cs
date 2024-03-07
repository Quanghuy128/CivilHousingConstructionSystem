using CHC.Domain.Common;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos.Material;
using CHC.Domain.Dtos.Quotation;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.Interior
{
    public class InteriorDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public double TotalPrice { get; set; } = 0;

        public virtual ICollection<InteriorDetailDto> InteriorDetails { get; set; } = new List<InteriorDetailDto>();
        public virtual ICollection<MaterialDto> Materials { get; set; } = new List<MaterialDto>();
        public virtual ICollection<QuotationDto> Quotations { get; set; } = new List<QuotationDto>();
    }
}
