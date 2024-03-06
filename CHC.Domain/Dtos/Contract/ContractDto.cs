using CHC.Domain.Common;
using CHC.Domain.Dtos.Account;
using CHC.Domain.Enums;

namespace CHC.Domain.Dtos.Contract
{
    public class ContractDto : BaseEntity
    {
        public DateTime AgreementDate { get; set; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public ContractStatus Status { get; set; } = ContractStatus.Progressing;
    }
}
