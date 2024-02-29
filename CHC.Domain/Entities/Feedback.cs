using CHC.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("feedback")]
    public class Feedback : BaseEntity
    {
        [Column("content")]
        public string Content { get; set; } = string.Empty;

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Account Customer { get; set; } = null!;
    }
}
