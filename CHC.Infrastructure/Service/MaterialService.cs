using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Material;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHC.Infrastructure.Service
{
    public class MaterialService : BaseService<MaterialService>, IMaterialService
    {
        public MaterialService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<MaterialService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public Task<MaterialDto> Create(CreateMaterialRequest createMaterial)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<MaterialDto> Get(Guid id)
        {
            Material material = await _unitOfWork.GetRepository<Material>().SingleOrDefaultAsync(predicate: p => p.Id.Equals(id));
            return _mapper.Map<MaterialDto>(material);
            
        }

        public async Task<List<MaterialDto>> GetAll()
        {
            ICollection<Material> materials = await _unitOfWork.GetRepository<Material>().GetListAsync();
            return _mapper.Map<List<MaterialDto>>(materials);
        }

        public Task<IPaginate<MaterialDto>> GetMaterials()
        {
            throw new NotImplementedException();
        }
    }
}
