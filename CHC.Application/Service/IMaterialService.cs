using CHC.Domain.Dtos.Material;
using CHC.Domain.Entities;
using System.Linq.Expressions;

namespace CHC.Application.Service
{
	public interface IMaterialService
	{
		public Task<List<MaterialDto>> GetAll();
		public Task<MaterialViewModel> GetOneByCondition(Expression<Func<Material, bool>> predicate);
    }
}
