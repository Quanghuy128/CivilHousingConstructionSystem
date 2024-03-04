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
        public string ImageUrl { get; set; } = string.Empty;
        public RoleType Role { get; set; } = RoleType.Customer;
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();
    }
}
