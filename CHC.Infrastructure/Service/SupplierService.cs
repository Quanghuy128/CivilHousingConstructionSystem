using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Supplier;
using CHC.Domain.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CHC.Infrastructure.Service
{
    public class SupplierService : BaseService<SupplierService>, ISupplierService
    {
        public SupplierService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<SupplierService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<List<SupplierDto>> GetAll()
        {
            ICollection<Supplier> suplliers = await _unitOfWork.GetRepository<Supplier>().GetListAsync();
            return _mapper.Map<List<SupplierDto>>(suplliers);
        }
    }
}
