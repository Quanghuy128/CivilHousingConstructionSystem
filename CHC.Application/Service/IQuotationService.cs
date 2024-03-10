using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHC.Application.Service
{
    public interface IQuotationService
    {
        Task<List<QuotationDto>> GetAll();
        Task<IPaginate<QuotationDto>> Paginate(string? search, int page, int pageSize);
        Task<IPaginate<QuotationDto>> GetQuotations();
        Task<QuotationDto> Get(Guid id);
        Task<QuotationDto> Create(CreateQuotationRequest createQuotation);
        //Task<bool> Update(UpdateQuotationRequest updateQuotation);
        Task<bool> Delete(Guid id);
    }
}
