using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Contract;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContractDto>(contract);
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContractDto> Get(Guid id)
        {
            Contract contract = (await _unitOfWork.GetRepository<Contract>()
                .SingleOrDefaultAsync(
                    predicate: x => x.Id.Equals(id),
                    include: x => x.Include(x => x.Customer)
                                    .Include(x => x.Staff)
                                    .Include(x => x.Quotation).ThenInclude(x => x.Interior)
                ));
            return _mapper.Map<ContractDto>(contract);
        }

        public async Task<List<ContractDto>> GetAll(Expression<Func<Contract, bool>> predicate)
        {
            IList<Contract> contracts = (await _unitOfWork.GetRepository<Contract>()
                .GetListAsync(
                    predicate: predicate,
                    include: x => x.Include(x => x.Customer)
                                    .Include(x => x.Staff)
                                    .Include(x => x.Quotation).ThenInclude(x => x.Interior)
                )).ToList();
            return _mapper.Map<List<ContractDto>>(contracts);
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
                                    .Include(x => x.Quotation).ThenInclude(x => x.Interior)
				);
            return _mapper.Map<IPaginate<ContractDto>>(contracts);
        }

        public async Task<bool> Update(UpdateContractRequest updateContractRequest)
        {
            Contract contract = await _unitOfWork.GetRepository<Contract>()
                .SingleOrDefaultAsync(
                    predicate: x => x.Id.Equals(updateContractRequest.Id),
                    include: x => x.Include(x => x.Customer)
                                    .Include(x => x.Staff)
                                    .Include(x => x.Quotation).ThenInclude(x => x.Interior)
                );

            contract.Content = updateContractRequest.Content;
            contract.FinalOffer = updateContractRequest.FinalOffer;
            contract.Discount = updateContractRequest.Discount;
            contract.StaffId = updateContractRequest.StaffId;
            contract.CustomerId = updateContractRequest.CustomerId;
            contract.Status = updateContractRequest.Status;

            _unitOfWork.GetRepository<Contract>().UpdateAsync(contract);
            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}
