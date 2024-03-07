using CHC.Domain.Dtos.Account;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using System.Linq.Expressions;

namespace CHC.Application.Service
{
    public interface IInteriorService
    {
        Task<List<InteriorDto>> GetAll();
        Task<IPaginate<InteriorDto>> GetPagination(string? search, int page, int pageSize);
        Task<InteriorDto> Get(Guid id);
        Task<InteriorDto> GetByCondition(Expression<Func<Interior, bool>> predicate);
        //Task<InteriorDto> Create(CreateAccountRequest createAccount);
        //Task<bool> Update(UpdateAccountRequest updateAccount);
        Task<bool> Delete(Guid id);
    }
}
