using CHC.Domain.Common;
using CHC.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("material")]
    public class Material : BaseEntity
    {
        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("price")]
        public string Price { get; set; } = string.Empty;

        [Column("type")]
        public string Type { get; set; } = string.Empty;

        [Column("size")]
        public string Size { get; set; } = string.Empty;

        [Column("status")]
        [EnumDataType(typeof(MaterialStatus))]
        public MaterialStatus Status { get; set; } = MaterialStatus.UpComing;

        [Column("category_id")]
        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        [Column("supplier_id")]
        [ForeignKey(nameof(Supplier))]
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

        [Column("owner_id")]
        [ForeignKey("OwnerAccounts")]
        public Guid OwnerId { get; set; }
        public virtual ICollection<Account> OwnerAccounts { get; set; } = new List<Account>();

        [Column("seller_id")]
        [ForeignKey("SellerAccount")]
        public Guid SellerId { get; set; }
        public virtual Account SellerAccount { get; set; } = null!;

        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>(); 
    }
}
