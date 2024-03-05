using CHC.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CHC.Domain.Dtos.Quotation
{
    public class QuotationDto : BaseEntity
    {
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public double EstimatePrice { get; set; } = 0;
        public string Content { get; set; } = string.Empty;
    }
}
