using CHC.Domain.Dtos.Account;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using System.Linq.Expressions;

namespace CHC.Application.Service
{
    public interface IAccountService
    {
        Task<AccountDto> Login(string username, string password);
        Task<List<AccountDto>> GetAll(Expression<Func<AccountDto, bool>>? predicate);
        Task<IPaginate<AccountDto>> GetPagination(Expression<Func<AccountDto, bool>>? predicate);
        Task<AccountDto> Get(Guid id);
        Task<AccountDto> GetByCondition(Expression<Func<Account, bool>> predicate);
        Task<AccountDto> Create(CreateAccountRequest createAccount);
        Task<bool> Update(UpdateAccountRequest updateAccount);
        Task<bool> Delete(Guid id);
    }
}
