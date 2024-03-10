using CHC.Application.Service;
using CHC.Domain.Dtos;
using CHC.Domain.Dtos.Contract;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Entities;
using CHC.Domain.Enums;
using CHC.Domain.Pagination;
using CHC.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace CHC.Presentation.Pages.QuotationView
{
    public class TrackingModel : PageModel
    {
        private readonly IInteriorDetailService interiorDetailService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IQuotationService quotationService;

        public TrackingModel(IInteriorDetailService interiorDetailService, IHttpContextAccessor httpContextAccessor, IQuotationService quotationService)
        {
            this.interiorDetailService = interiorDetailService;
            this.httpContextAccessor = httpContextAccessor;
            this.quotationService = quotationService;
        }

        [BindProperty(SupportsGet = true)]
        public IList<InteriorDetailDto> InteriorDetails { get; set; } = new List<InteriorDetailDto>();

        [BindProperty(SupportsGet = true)]
        public IList<QuotationDto> Quotations { get; set; } = new List<QuotationDto>();

        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public string? SearchString { get; set; } = string.Empty;
        public double TotalPrice { get; set; } = 0;

        public async Task<IActionResult> OnGetAsync(int? pageIndex, int? size)
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            if (pageIndex is not null) PageIndex = pageIndex.Value;
            if (size is not null) PageSize = size.Value;

            IPaginate<QuotationDto> contracts = await quotationService
                .GetPagination(x => x.Content.Contains(SearchString), PageIndex, PageSize);
            Quotations = contracts.Items;
            TotalPages = contracts.TotalPages;

            foreach (var item in InteriorDetails)
            {
                TotalPrice += item.Quantity * item.Material.Price;
            }
            TotalPrice += (100 + 70);
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            await quotationService.Delete(new Guid(id));
            return Redirect("/QuotationView/Tracking?pageIndex="+PageIndex);
        }
    }
}
