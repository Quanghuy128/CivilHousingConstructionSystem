using CHC.Domain.Common;
using CHC.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("material")]
    public class Material : BaseEntity
    {
        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("image_url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Column("price")]
        public double Price { get; set; } = 0;  

        public virtual ICollection<InteriorDetail> InteriorDetails { get; set; } = new List<InteriorDetail>();
    }
}
