using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CHC.Domain.Common;
using CHC.Domain.Enums;

namespace CHC.Domain.Entities
{
    [Table("account")]
    public class Account : BaseEntity
    {
        [Column("username")]
        [Required]
        public string Username { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("fullname")]
        [StringLength(500)]
        public string FullName { get; set; } = string.Empty;

        [Column("email")]
        [Required]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Column("phone_number")]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column("address")]
        [StringLength(500)]
        public string Address {  get; set; } = string.Empty;

        [Column("role")]
        [EnumDataType(typeof(RoleType))]
        public RoleType Role { get; set; } = RoleType.Customer;

        [Column("status")]
        [EnumDataType(typeof(AccountStatus))]
        public AccountStatus Status { get; set; } = AccountStatus.Active;

        [InverseProperty("OwnerAccounts")]
        public virtual ICollection<Material> OwnedMaterials { get; set; } = new List<Material>();

        [InverseProperty("SellerAccount")]
        public virtual ICollection<Material> SellMaterials { get; set; } = new List<Material>();

        [InverseProperty("Customer")]
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
