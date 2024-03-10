namespace CHC.Domain.Dtos.Quotation
{
    public class CreateQuotaionRequest
    {
        public double EstimatePrice { get; set; } = 0;
        public string Content { get; set; } = string.Empty;
        public Guid CustomerId { get; set; }
    }
}
