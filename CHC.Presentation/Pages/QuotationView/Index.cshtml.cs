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

		public IndexModel(IInteriorDetailService interiorDetailService, IHttpContextAccessor httpContextAccessor)
		{
			this.interiorDetailService = interiorDetailService;
			this.httpContextAccessor = httpContextAccessor;
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

        public async Task<IActionResult> OnPostConfirmAsync()
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }



            return Redirect("/QuotationView/Tracking");
        }
    }
}
