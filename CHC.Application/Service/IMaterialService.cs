using CHC.Domain.Dtos.Material;

namespace CHC.Application.Service
{
	public interface IMaterialService
	{
		public Task<List<MaterialDto>> GetAll();
	}
}
