using CHC.Domain.Common;
using CHC.Domain.Enums;

namespace CHC.Domain.Dtos.Account
{
    public class AccountViewModel : BaseEntity
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
    }
}
