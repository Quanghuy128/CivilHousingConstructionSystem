using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHC.Domain.Dtos.Material
{
    public class CreateMaterialRequest
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
    }
}
