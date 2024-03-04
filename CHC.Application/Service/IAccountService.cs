using CHC.Domain.Dtos.Account;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using System.Linq.Expressions;

namespace CHC.Application.Service
{
    public interface IAccountService
    {
        Task<AccountDto> Login(string username, string password);
        Task<List<AccountDto>> GetAll();
        Task<IPaginate<AccountDto>> GetAccounts();
        Task<AccountDto> Get(Guid id);
        Task<AccountDto> GetByCondition(Expression<Func<Account, bool>> predicate);
        Task<AccountDto> Create(CreateAccountRequest createAccount);
        Task<bool> Update(UpdateAccountRequest updateAccount);
        Task<bool> Delete(Guid id);
    }
}
