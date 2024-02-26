using CHC.Domain.Dtos.Account;
using CHC.Domain.Entities;

namespace CHC.Application.IService
{
    public interface IAccountService
    {
        Task<AccountDto> Login(string username, string password);
    }
}
