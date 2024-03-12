using CHC.Domain.Enums;

namespace CHC.Domain.Dtos.Quotation
{
	public class UpdateQuotationRequest
	{
		public Guid Id { get; set; }
		public double EstimatePrice { get; set; } = 0;
		public string Content { get; set; } = string.Empty;
		public double ShippingCost { get; set; } = 0;
		public double ConstructionCost { get; set; } = 0;
		public Guid CustomerId { get; set; }
		public Guid InteriorId { get; set; }
		public QuotationStatus Status { get; set; } = QuotationStatus.Pending;

	}
}
