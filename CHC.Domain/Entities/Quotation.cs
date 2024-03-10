﻿using CHC.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CHC.Domain.Entities
{
    [Table("quotation")]
    public class Quotation : BaseEntity
    {
        [Column("request_date")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Column("estimate_price")]
        public double EstimatePrice { get; set; } = 0;

        [Column("content")]
        [StringLength(500)]
        public string Content { get; set; } = string.Empty;

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Account Customer { get; set; } = null!;

        [Column("interior_id")]
        [ForeignKey("Interior")]
        public Guid InteriorId { get; set; }
        public virtual Interior Interior { get; set; } = null!;
    }
}
