using CHC.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("transaction_detail")]
    public class TransactionDetail : BaseEntity
    {
        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("transaction_id")]
        [ForeignKey(nameof(Transaction))]
        public Guid TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; } = null!;

        [Column("material_id")]
        [ForeignKey(nameof(Material))]
        public Guid MaterialId { get; set; }
        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
