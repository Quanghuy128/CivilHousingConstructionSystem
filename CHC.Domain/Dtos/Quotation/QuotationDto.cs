using CHC.Domain.Common;
using CHC.Domain.Dtos.Account;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.Quotation
{
    public class QuotationDto : BaseEntity
    {
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public double EstimatePrice { get; set; } = 0;
        public string Content { get; set; } = string.Empty;
        public double ShippingCost { get; set; } = 0;
        public double ConstructionCost { get; set; } = 0; public QuotationStatus Status { get; set; } = QuotationStatus.Pending;
        public virtual AccountViewModel Customer { get; set; } = null!;
        public virtual InteriorDto Interior { get; set; } = null!;
        public virtual ICollection<InteriorDetailDto> InteriorDetails { get; set; } = null!;
    }
}
