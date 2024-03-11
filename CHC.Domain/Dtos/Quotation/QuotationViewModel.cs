using CHC.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.Quotation
{
    public class QuotationViewModel
    {
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public double EstimatePrice { get; set; } = 0;
        public string Content { get; set; } = string.Empty;
        public double ShippingCost { get; set; } = 0;
        public double ConstructionCost { get; set; } = 0; 
        public QuotationStatus Status { get; set; } = QuotationStatus.Pending;
    }
}
