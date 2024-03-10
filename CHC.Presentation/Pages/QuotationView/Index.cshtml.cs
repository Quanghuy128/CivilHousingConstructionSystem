using CHC.Application.Service;
using CHC.Domain.Dtos;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Enums;
using CHC.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages.QuotationView
{
    public class IndexModel : PageModel
    {
        private readonly IInteriorDetailService interiorDetailService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IQuotationService quotationService;

        public IndexModel(IInteriorDetailService interiorDetailService, IHttpContextAccessor httpContextAccessor, IQuotationService quotationService)
		{
			this.interiorDetailService = interiorDetailService;
			this.httpContextAccessor = httpContextAccessor;
            this.quotationService = quotationService;
		}

        [BindProperty(SupportsGet = true)]
        public IList<InteriorDetailDto> InteriorDetails { get; set; } = new List<InteriorDetailDto>();
        public string Message { get; set; } = string.Empty;
        public double TotalPrice { get; set; } = 0;

		public async Task<IActionResult> OnGetAsync(Guid interiorId)
        {
            InteriorDetails = await interiorDetailService.GetAll(predicate: x => x.InteriorId.Equals(interiorId));
            foreach (var item in InteriorDetails)
            {
                TotalPrice += item.Quantity * item.Material.Price;
            }
            TotalPrice += (100 + 70);
            return Page();
        }

        public async Task<IActionResult> OnPostConfirmAsync(string interiorId, double price)
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            CreateQuotaionRequest createQuotaionRequest = new CreateQuotaionRequest()
            {
                EstimatePrice = price,
                CustomerId = current.Id,
                InteriorId = new Guid(interiorId),
            };

            var result = await quotationService.Create(createQuotaionRequest);
            if (result == null) return Page();
            return Redirect("/QuotationView/Tracking");
        }
    }
}
