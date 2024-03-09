using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Material;
using CHC.Domain.Entities;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CHC.Infrastructure.Service
{
	public class MaterialService : BaseService<MaterialService>, IMaterialService
	{
		public MaterialService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<MaterialService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
		{
		}

		public async Task<List<MaterialDto>> GetAll()
		{
			List<Material> materials = (await _unitOfWork.GetRepository<Material>().GetListAsync()).ToList();
			return _mapper.Map<List<MaterialDto>>(materials);
		}
	}
}
