using CHC.Domain.Common;
using CHC.Domain.Enums;

namespace CHC.Domain.Dtos.Contract
{
    public class ContractViewModel : BaseEntity
    {
        public DateTime AgreementDate { get; set; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public double FinalOffer { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public ContractStatus Status { get; set; } = ContractStatus.Progressing;
    }
}
