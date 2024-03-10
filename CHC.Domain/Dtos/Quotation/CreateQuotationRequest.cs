
namespace CHC.Domain.Dtos.Quotation
{
    public class CreateQuotationRequest
    {
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public double EstimatePrice { get; set; } = 0;
        public string Content { get; set; } = string.Empty;
        public Guid CustomerId { get; set; } = Guid.Empty;
    }
}
