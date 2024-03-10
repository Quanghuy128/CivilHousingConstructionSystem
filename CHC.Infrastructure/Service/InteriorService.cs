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

		public async Task<InteriorDto> Create(CreateInteriorRequest createInteriorRequest)
		{
            Interior interior = _mapper.Map<Interior>(createInteriorRequest);
			await _unitOfWork.GetRepository<Interior>().InsertAsync(interior);
			bool isSuccessfull = await _unitOfWork.CommitAsync() > 0;
			if (!isSuccessfull) return null!;
            return _mapper.Map<InteriorDto>(interior);
		}

		public async Task<bool> Delete(Guid id)
        {
            Interior interior = await _unitOfWork.GetRepository<Interior>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(id));
            if (interior is null) return false;
            interior.IsDeleted = true;
            _unitOfWork.GetRepository<Interior>().UpdateAsync(interior);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public async Task<InteriorDto> Get(Guid id)
        {
            Interior interior = await _unitOfWork.GetRepository<Interior>()
                .SingleOrDefaultAsync(
                predicate: x => x.Id.Equals(id),
                include: x => x.Include(x => x.Staff)
								.Include(x => x.InteriorDetails)
                                .ThenInclude(x => x.Material)
                                .Include(x => x.Quotations)
                );
            return _mapper.Map<InteriorDto>(interior);
        }

        public async Task<List<InteriorDto>> GetAll(Expression<Func<Interior, bool>> predicate)
        {
            List<Interior> interiors = (await _unitOfWork.GetRepository<Interior>()
                .GetListAsync(
                predicate: predicate,
                include: x => x.Include(x => x.Staff)
								.Include(x => x.InteriorDetails)
								.ThenInclude(x => x.Material)
								.Include(x => x.Quotations))).ToList();
            return _mapper.Map<List<InteriorDto>>(interiors);
        }

        public Task<InteriorDto> GetByCondition(Expression<Func<Interior, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IPaginate<InteriorDto>> GetPagination(Expression<Func<Interior, bool>> predicate, int page, int pageSize)
        {
            var interiors = await _unitOfWork.GetRepository<Interior>().GetPagingListAsync(
                predicate: predicate,
                page: page,
                size: pageSize,
                orderBy: x => x.OrderByDescending(x => x.CreatedAt),
                include: x => x.Include(x => x.Staff)
                                .Include(x => x.InteriorDetails)
                                .ThenInclude(x => x.Material)
                                .Include(x => x.Quotations)
                );
            return _mapper.Map<IPaginate<InteriorDto>>(interiors);
        }
    }
}
