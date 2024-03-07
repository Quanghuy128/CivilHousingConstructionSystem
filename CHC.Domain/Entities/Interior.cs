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

        [Column("location")]
        public string Location { get; set; } = string.Empty;

        [Column("total_price")]
        public double TotalPrice { get; set; } = 0;

        public virtual ICollection<InteriorDetail> InteriorDetails { get; set; } = new List<InteriorDetail>();
        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
        public virtual ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();

    }
}
