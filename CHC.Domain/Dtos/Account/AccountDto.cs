using CHC.Domain.Entities;
using CHC.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CHC.Domain.Common;

namespace CHC.Domain.Dtos.Account
{
    public class AccountDto : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public RoleType Role { get; set; } = RoleType.Customer;
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        public virtual ICollection<Material> OwnedMaterials { get; set; } = new List<Material>();
        public virtual ICollection<Material> SellMaterials { get; set; } = new List<Material>();
        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
