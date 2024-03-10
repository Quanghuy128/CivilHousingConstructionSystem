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
using CHC.Domain.Enums;
using CHC.Infrastructure.Service;
using CHC.Presentation.Extensions;

namespace CHC.Presentation.Pages.QuotationView
{
    public class IndexModel : PageModel
    {
        private readonly IQuotationService _quotationService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public IndexModel(IQuotationService quotationService, IHttpContextAccessor httpContextAccessor)
        {
            _quotationService = quotationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<QuotationDto> Quotation { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            SessionUser current = _httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role == RoleType.Customer)
            {
                _httpContextAccessor.HttpContext.Session.Clear();
                Response.Redirect("/Login");
            }
            Quotation = await _quotationService.GetAll();
            return Page();
        }
    }
}
