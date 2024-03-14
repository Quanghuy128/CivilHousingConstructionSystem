using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing.Printing;
using System.Linq.Expressions;

namespace CHC.Infrastructure.Service
{
    public class QuotationService : BaseService<QuotationService>, IQuotationService
    {
        public QuotationService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<QuotationService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<QuotationDto> Create(CreateQuotaionRequest createQuotaionRequest)
        {
            Quotation existedQuotation = await _unitOfWork.GetRepository<Quotation>()
                .SingleOrDefaultAsync(
                    predicate: x => x.CustomerId.Equals(createQuotaionRequest.CustomerId) && x.InteriorId.Equals(createQuotaionRequest.InteriorId)
                );
            if (existedQuotation is not null) return null!;

            Quotation quotation = _mapper.Map<Quotation>(createQuotaionRequest);
            await _unitOfWork.GetRepository<Quotation>().InsertAsync(quotation);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<QuotationDto>(quotation);
        }

        public async Task<bool> Delete(Guid id)
        {
            Quotation quotation = await _unitOfWork.GetRepository<Quotation>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
            _unitOfWork.GetRepository<Quotation>().DeleteAsync(quotation);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public async Task<QuotationDto> Get(Guid id)
        {
			Quotation quotation = (await _unitOfWork.GetRepository<Quotation>()
				 .SingleOrDefaultAsync(
					 predicate: x => x.Id.Equals(id),
					 include: x => x.Include(x => x.Customer)
									 .Include(x => x.Interior).ThenInclude(x => x.InteriorDetails).ThenInclude(x => x.Material)
				 ));
            return _mapper.Map<QuotationDto>(quotation);
		}

        public async Task<IList<QuotationDto>> GetAll(Expression<Func<Quotation, bool>> predicate)
        {
            IList<Quotation> quotations = (await _unitOfWork.GetRepository<Quotation>()
                .GetListAsync(
                    predicate: predicate,
                    orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                    include: x => x.Include(x => x.Customer)
                                    .Include(x => x.Interior).ThenInclude(x => x.InteriorDetails).ThenInclude(x => x.Material)
                )).ToList();
            return _mapper.Map<IList<QuotationDto>>(quotations);
        }

        public Task<QuotationDto> GetByCondition(Expression<Func<Quotation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IPaginate<QuotationDto>> GetPagination(Expression<Func<Quotation, bool>> predicate, int page, int pageSize)
        {
            IPaginate<Quotation> quotations = await _unitOfWork.GetRepository<Quotation>()
                .GetPagingListAsync(
                    predicate: predicate,
                    page: page,
                    size: pageSize,
                    orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                    include: x => x.Include(x => x.Customer)
                                    .Include(x => x.Interior).ThenInclude(x => x.InteriorDetails).ThenInclude(x => x.Material)
                );
            return _mapper.Map<IPaginate<QuotationDto>>(quotations);
        }

		public async Task<bool> Update(UpdateQuotationRequest updateQuotationRequest)
		{
			Quotation quotation = await _unitOfWork.GetRepository<Quotation>()
                .SingleOrDefaultAsync(
                    predicate: x => x.Id.Equals(updateQuotationRequest.Id), 
                    include: x => x.Include(x => x.Customer)
									    .Include(x => x.Interior).ThenInclude(x => x.InteriorDetails).ThenInclude(x => x.Material));

            quotation.EstimatePrice = updateQuotationRequest.EstimatePrice;
            quotation.Content = updateQuotationRequest.Content;
            quotation.ShippingCost = updateQuotationRequest.ShippingCost;
            quotation.ConstructionCost = updateQuotationRequest.ConstructionCost;
            quotation.CustomerId = updateQuotationRequest.CustomerId;
            quotation.InteriorId = updateQuotationRequest.InteriorId;
            quotation.Status = updateQuotationRequest.Status;

			_unitOfWork.GetRepository<Quotation>().UpdateAsync(quotation);
            return await _unitOfWork.CommitAsync() > 0;
		}
	}
}
