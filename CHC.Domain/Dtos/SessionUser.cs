using CHC.Domain.Enums;

namespace CHC.Domain.Dtos
{
    public class SessionUser
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public RoleType Role {  get; set; } = RoleType.Customer;
    }
}
