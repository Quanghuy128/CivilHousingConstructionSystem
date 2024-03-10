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
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Dtos;
using CHC.Presentation.Extensions;
using CHC.Domain.Enums;

namespace CHC.Presentation.Pages.QuotationView
{
    public class DeleteModel : PageModel
    {
        private readonly IQuotationService _quotationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteModel(IQuotationService quotationService, IHttpContextAccessor httpContextAccessor)
        {
            _quotationService = quotationService;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public QuotationDto Quotation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            SessionUser current = _httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Admin)
            {
                _httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");

            }

            if (id == null)
            {
                return NotFound();
            }

            QuotationDto quotation = await _quotationService.Get(id);

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

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            bool result = await _quotationService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
