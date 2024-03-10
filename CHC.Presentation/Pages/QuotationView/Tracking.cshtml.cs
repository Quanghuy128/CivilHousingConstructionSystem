using CHC.Application.Service;
using CHC.Domain.Dtos;
using CHC.Domain.Dtos.Contract;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Enums;
using CHC.Domain.Pagination;
using CHC.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages.QuotationView
{
    public class TrackingModel : PageModel
    {
        private readonly IInteriorDetailService interiorDetailService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IContractService contractService;

        public TrackingModel(IInteriorDetailService interiorDetailService, IHttpContextAccessor httpContextAccessor, IContractService contractService)
        {
            this.interiorDetailService = interiorDetailService;
            this.httpContextAccessor = httpContextAccessor;
            this.contractService = contractService;
        }

        [BindProperty(SupportsGet = true)]
        public IList<InteriorDetailDto> InteriorDetails { get; set; } = new List<InteriorDetailDto>();

        [BindProperty(SupportsGet = true)]
        public IList<ContractDto> Contracts { get; set; } = new List<ContractDto>();

        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 3;
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public string? SearchString { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            IPaginate<ContractDto> contracts = await contractService
                .GetPagination(x => x.Content.Contains(SearchString), PageIndex, PageSize);
            Contracts = contracts.Items;
            TotalPages = contracts.TotalPages;

            return Page();
        }
    }
}
