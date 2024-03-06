using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CHC.Infrastructure.Service
{
    public class InteriorService : BaseService<InteriorService>, IInteriorService
    {
        public InteriorService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<InteriorService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<InteriorDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InteriorDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<InteriorDto> GetByCondition(Expression<Func<Interior, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IPaginate<InteriorDto>> GetPagination(string? search, int page, int pageSize)
        {
            var interiors = await _unitOfWork.GetRepository<Interior>().GetPagingListAsync(
                predicate: x => x.Name.Contains(search!) || x.Description.Contains(search!),
                page: page,
                size: pageSize,
                include: x => x.Include(x => x.InteriorDetail).Include(x => x.Quotations)
                );
            return _mapper.Map<IPaginate<InteriorDto>>(interiors);
        }
    }
}
