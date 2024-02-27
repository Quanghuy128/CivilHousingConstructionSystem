using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CHC.Domain.Entities;
using CHC.Infrastructure;
using CHC.Application.Service;
using CHC.Domain.Dtos.Supplier;

namespace CHC.Presentation.Pages.SupplierView
{
    public class IndexModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public IndexModel(ISupplierService supplierService)
        {
           _supplierService = supplierService;
        }

        public IList<SupplierDto> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Supplier = await _supplierService.GetAll();
        }
    }
}
