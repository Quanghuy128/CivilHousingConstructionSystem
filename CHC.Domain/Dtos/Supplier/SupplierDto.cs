using CHC.Domain.Common;
using CHC.Domain.Entities;

namespace CHC.Domain.Dtos.Supplier
{
    public class SupplierDto : BaseEntity
    {
        public string Name { get; set; }
        public int FoundedYear { get; set; }
        public virtual ICollection<Material> ProvidedMaterials { get; set; } = new List<Material>();
    }
}
