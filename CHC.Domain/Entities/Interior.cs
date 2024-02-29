using CHC.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("interior")]
    public class Interior : BaseEntity
    {
        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        public virtual InteriorDetail InteriorDetail { get; set; } = null!;
        public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    }
}
