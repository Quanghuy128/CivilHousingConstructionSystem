using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Entities;
using System.Linq.Expressions;

namespace CHC.Application.Service
{
    public interface IInteriorDetailService
    {
        Task<List<InteriorDetailDto>> GetAll(Expression<Func<InteriorDetail, bool>> predicate);
        Task<bool> AddRange(List<InteriorDetailDto> interiorDetails);
        Task<bool> Update(CreateInterialDetailRequest createInterialDetailRequest);
    }
}
