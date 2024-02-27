using CHC.Domain.Dtos.Supplier;

namespace CHC.Application.Service
{
    public interface ISupplierService
    {
        Task<List<SupplierDto>> GetAll();
    }
}
