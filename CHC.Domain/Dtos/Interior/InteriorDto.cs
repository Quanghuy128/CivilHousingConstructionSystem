using CHC.Domain.Common;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos.Quotation;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.Interior
{
    public class InteriorDto : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual InteriorDetailDto InteriorDetail { get; set; } = null!;
        public virtual ICollection<QuotationDto> Quotations { get; set; } = new List<QuotationDto>();
    }
}
