using CHC.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("category")]
    public class Category : BaseEntity
    {
        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
