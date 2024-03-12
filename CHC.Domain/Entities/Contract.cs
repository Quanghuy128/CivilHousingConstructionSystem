using CHC.Domain.Common;
using CHC.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("contract")]
    public class Contract : BaseEntity
    {
        [Column("agreement_date")]
        public DateTime AgreementDate { get; set; } = DateTime.Now;

        [Column("content")]
        [StringLength(500)]
        public string Content { get; set; } = string.Empty;

        [Column("final_offer")]
        public double FinalOffer { get; set; } = 0;

        [Column("discount")]
        public int Discount { get; set; } = 0;

        [Column("status")]
        [EnumDataType(typeof(ContractStatus))]
        public ContractStatus Status { get; set; } = ContractStatus.Progressing;

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Account Customer { get; set; } = null!;

        [Column("staff_id")]
        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public virtual Account Staff { get; set; } = null!;

        [Column("interior_id")]
        [ForeignKey("Interior")]
        public Guid InteriorId { get; set; }
        public virtual Interior Interior { get; set; } = null!;
    }
}
