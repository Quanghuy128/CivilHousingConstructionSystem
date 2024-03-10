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
			double totalPrice = 0;
			foreach (var item in interiors)
			{
				totalPrice += item.Material.Price;

			}

			Interior interior = await _unitOfWork.GetRepository<Interior>().SingleOrDefaultAsync(predicate: x => x.Id.Equals(interiorDetails[0].InteriorId));
			interior.TotalPrice = totalPrice;
			return await _unitOfWork.CommitAsync() > 0;
        }

        public async Task<bool> Update(CreateInterialDetailRequest createInterialDetailRequest)
        {
            InteriorDetail interiorDetail = _mapper.Map<InteriorDetail>(createInterialDetailRequest);
            _unitOfWork.GetRepository<InteriorDetail>().UpdateAsync(interiorDetail);

            double totalPrice = 0;
            List<InteriorDetail> interiorDetails = (await _unitOfWork.GetRepository<InteriorDetail>()
                .GetListAsync(
                predicate: x => x.InteriorId.Equals(createInterialDetailRequest.InteriorId),
                include: x => x.Include(x => x.Material))).ToList();
            foreach (var item in interiorDetails)
            {
                totalPrice += item.Quantity * item.Material.Price;
			}

            Interior interior =  await _unitOfWork.GetRepository<Interior>().SingleOrDefaultAsync(predicate:  x=> x.Id.Equals(interiorDetail.InteriorId));
            interior.TotalPrice = totalPrice;
			_unitOfWork.GetRepository<Interior>().UpdateAsync(interior);

			return await _unitOfWork.CommitAsync() > 0;
        }
    }
}
