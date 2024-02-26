using CHC.Domain.Dtos.Account;
using CHC.Domain.Entities;

namespace CHC.Application.Service
{
    public interface IAccountService
    {
        Task<AccountDto> Login(string username, string password);
        Task<List<AccountDto>> GetAll();
    }
}
