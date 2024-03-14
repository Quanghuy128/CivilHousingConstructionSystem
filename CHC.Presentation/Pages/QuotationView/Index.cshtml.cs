using CHC.Application.Service;
using CHC.Domain.Dtos;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Enums;
using CHC.Infrastructure.Service;
using CHC.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        object[] ConstructionCostoptions = new[] {
            new {
                Name = "Fastest Construction (3 Days) - 100$",
                Value = 100
            },
            new {
                Name = "Tomorrow Construction (1 Week) - 70$",
                Value = 70
            },
            new {
                Name = "Standard Construction (2 Weeks) - 50$",
                Value = 50
            },
            new {
                Name = "Frees",
                Value = 0
            },
        };
        object[] DeliveryOptions = new[] {
            new {
                Name = "Fastest Delivery (3 Days) - 100$",
                Value = 100
            },
            new {
                Name = "Tomorrow Delivery (1 Week) - 70$",
                Value = 70
            },
            new {
                Name = "Standard Delivery (2 Weeks) - 50$",
                Value = 50
            },
            new {
                Name = "Frees",
                Value = 0
            },
        };

        public async Task<IActionResult> OnGetAsync(Guid interiorId)
        {
            InteriorDetails = await interiorDetailService.GetAll(predicate: x => x.InteriorId.Equals(interiorId));
            foreach (var item in InteriorDetails)
            {
                TotalPrice += item.Quantity * item.Material.Price;
            }
            ViewData["ConstructionOptions"] = new SelectList(ConstructionCostoptions, "Value", "Name");
            ViewData["DeliveryOptions"] = new SelectList(DeliveryOptions, "Value", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostConfirmAsync(string interiorId, double price, double shippingCost, double constructionCost)
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            CreateQuotaionRequest createQuotaionRequest = new CreateQuotaionRequest()
            {
                EstimatePrice = price + shippingCost + constructionCost,
                CustomerId = current.Id,
                InteriorId = new Guid(interiorId),
                ShippingCost = shippingCost,
                ConstructionCost = constructionCost
            };

            var result = await quotationService.Create(createQuotaionRequest);
            if (result == null) return Page();
            return Redirect("/QuotationView/Tracking");
        }
    }
}
