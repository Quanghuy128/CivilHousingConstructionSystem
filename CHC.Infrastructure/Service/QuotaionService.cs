using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHC.Infrastructure.Service
{
    public class QuotaionService : BaseService<IQuotationService>, IQuotationService
    {
        public QuotaionService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<IQuotationService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<QuotationDto> Create(CreateQuotationRequest createQuotation)
        {
            Quotation quotation = _mapper.Map<Quotation>(createQuotation);

            await _unitOfWork.GetRepository<Quotation>().InsertAsync(quotation);
            bool isSuccessfull = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessfull) return null!;
            return _mapper.Map<QuotationDto>(quotation);
        }

        public async Task<bool> Delete(Guid id)
        {
            Quotation quotation = _mapper.Map<Quotation>(await Get(id));
            if (quotation == null) return false;

            _unitOfWork.GetRepository<Quotation>().DeleteAsync(quotation);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public async Task<QuotationDto> Get(Guid id)
        {
            Quotation quotation = await _unitOfWork.GetRepository<Quotation>().SingleOrDefaultAsync(predicate: p => p.Id.Equals(id));
            return _mapper.Map<QuotationDto>(quotation);
        }

        public async Task<List<QuotationDto>> GetAll()
        {
            ICollection<Quotation> quotations = await _unitOfWork.GetRepository<Quotation>().GetListAsync();
            return _mapper.Map<List<QuotationDto>>(quotations);
        }

        public Task<IPaginate<QuotationDto>> GetQuotations()
        {
            throw new NotImplementedException();
        }

        public Task<IPaginate<QuotationDto>> Paginate(string? search, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
