using CHC.Domain.Dtos.Material;
using CHC.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHC.Application.Service
{
    public interface IMaterialService
    {
        Task<List<MaterialDto>> GetAll();
        Task<IPaginate<MaterialDto>> GetMaterials();
        Task<MaterialDto> Get(Guid id);
        Task<MaterialDto> Create(CreateMaterialRequest createMaterial);
        //Task<bool> Update(UpdateMaterialRequest updateMaterial);
        Task<bool> Delete(Guid id);
    }
}
