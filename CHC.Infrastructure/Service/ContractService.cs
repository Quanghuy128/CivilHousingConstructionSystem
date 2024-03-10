using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Contract;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CHC.Infrastructure.Service
{
    public class ContractService : BaseService<ContractService>, IContractService
    {
        public ContractService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<ContractService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<ContractDto> Create(CreateContractRequest createContractRequest)
        {
            Contract contract = _mapper.Map<Contract>(createContractRequest);
            await _unitOfWork.GetRepository<Contract>().InsertAsync(contract);
            return _mapper.Map<ContractDto>(contract);
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ContractDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContractDto>> GetAll(Expression<Func<Contract, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ContractDto> GetByCondition(Expression<Func<Interior, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IPaginate<ContractDto>> GetPagination(Expression<Func<Contract, bool>> predicate, int page, int pageSize)
        {
            IPaginate<Contract> contracts = await _unitOfWork.GetRepository<Contract>()
                .GetPagingListAsync(
                    predicate: predicate,
                    orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                    page: page,
                    size: pageSize,
                    include: x => x.Include(x => x.Customer)
                                    .Include(x => x.Staff)
                                    .Include(x => x.Interior)
                );
            return _mapper.Map<IPaginate<ContractDto>>(contracts);
        }
    }
}
