using CHC.Domain.Dtos.Contract;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using System.Linq.Expressions;

namespace CHC.Application.Service
{
    public interface IContractService
    {
        Task<List<ContractDto>> GetAll(Expression<Func<Contract, bool>> predicate);
        Task<IPaginate<ContractDto>> GetPagination(Expression<Func<Contract, bool>> predicate, int page, int pageSize);
        Task<ContractDto> Get(Guid id);
        Task<ContractDto> GetByCondition(Expression<Func<Interior, bool>> predicate);
        Task<ContractDto> Create(CreateContractRequest createContractRequest);
        Task<bool> Update(UpdateContractRequest updateContractRequest);
        Task<bool> Delete(Guid id);
    }
}
