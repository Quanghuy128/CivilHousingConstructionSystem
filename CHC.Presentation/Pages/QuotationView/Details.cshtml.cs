using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CHC.Domain.Entities;
using CHC.Infrastructure;

namespace CHC.Presentation.Pages.QuotationView
{
    public class DetailsModel : PageModel
    {
        private readonly CHC.Infrastructure.ApplicationDbContext _context;

        public DetailsModel(CHC.Infrastructure.ApplicationDbContext context)
        {
            _context = context;
        }

        public Quotation Quotation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotations.FirstOrDefaultAsync(m => m.Id == id);
            if (quotation == null)
            {
                return NotFound();
            }
            else
            {
                Quotation = quotation;
            }
            return Page();
        }
    }
}
