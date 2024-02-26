using CHC.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("supplier")]
    public class Supplier : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Column("founded_year")]
        public int FoundedYear { get; set; } = 0;

        public virtual ICollection<Material> ProvidedMaterials { get; set; } = new List<Material>();
    }
}
