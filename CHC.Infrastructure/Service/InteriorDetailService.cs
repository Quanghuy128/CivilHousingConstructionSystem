using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CHC.Infrastructure.Service
{
    public class InteriorDetailService : BaseService<InteriorDetailService>, IInteriorDetailService
    {
        public InteriorDetailService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<InteriorDetailService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<List<InteriorDetailDto>> GetAll(Expression<Func<InteriorDetail, bool>> predicate)
        {
            List<InteriorDetail> interiorDetails = (await _unitOfWork.GetRepository<InteriorDetail>().GetListAsync(
                predicate: predicate,
                include: x => x.Include(x => x.Material).Include(x => x.Interior)
                )).ToList();
            return _mapper.Map<List<InteriorDetailDto>>(interiorDetails);
        }

        public async Task<bool> AddRange(List<InteriorDetailDto> interiorDetails)
        {
            List<InteriorDetail> interiors = _mapper.Map<List<InteriorDetail>>(interiorDetails);
            await _unitOfWork.GetRepository<InteriorDetail>().InsertRangeAsync(interiors);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public async Task<bool> Update(CreateInterialDetailRequest createInterialDetailRequest)
        {
            InteriorDetail interior = _mapper.Map<InteriorDetail>(createInterialDetailRequest);
            _unitOfWork.GetRepository<InteriorDetail>().UpdateAsync(interior);
            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}
