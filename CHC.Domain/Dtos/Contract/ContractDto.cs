using CHC.Domain.Common;
using CHC.Domain.Dtos.Account;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Dtos.Contract
{
    public class ContractDto : BaseEntity
    {
        public DateTime AgreementDate { get; set; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
        public double FinalOffer { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public ContractStatus Status { get; set; } = ContractStatus.Progressing;
        public virtual AccountViewModel Customer { get; set; } = null!;
        public virtual AccountViewModel Staff { get; set; } = null!;
        public virtual QuotationDto Quotation { get; set; } = null!;
    }
}
