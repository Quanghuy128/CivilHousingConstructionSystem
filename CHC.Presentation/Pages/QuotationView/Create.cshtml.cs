using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CHC.Domain.Entities;
using CHC.Infrastructure;
using CHC.Application.Service;
using CHC.Domain.Dtos.Quotation;

namespace CHC.Presentation.Pages.QuotationView
{
    public class CreateModel : PageModel
    {
        private readonly IQuotationService _quotationService;

        public CreateModel(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateQuotationRequest Quotation { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            QuotationDto result = await _quotationService.Create(Quotation);

            return RedirectToPage("./Index");
        }
    }
}
