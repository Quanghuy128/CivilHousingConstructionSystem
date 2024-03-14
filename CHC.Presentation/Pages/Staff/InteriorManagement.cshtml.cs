using CHC.Application.Service;
using CHC.Domain.Dtos;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Enums;
using CHC.Domain.Pagination;
using CHC.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHC.Presentation.Pages.Staff
{
    public class InteriorManagementModel : PageModel
    {
        private readonly IInteriorService interiorService;
		private readonly IHttpContextAccessor httpContextAccessor;
		
		public InteriorManagementModel(IInteriorService interiorService, IHttpContextAccessor httpContextAccessor, IMaterialService materialService)
		{
			this.interiorService = interiorService;
			this.httpContextAccessor = httpContextAccessor;
		}

		[BindProperty(SupportsGet = true)]
        public IList<InteriorDto> Interiors { get; set; } = new List<InteriorDto>();

        public int PageIndex { get; set; } = 1;
		public int TotalPages { get; set; }
		public int PageSize { get; set; } = 10;
		public bool HasNextPage => PageIndex < TotalPages;
		public bool HasPreviousPage => PageIndex > 1;
		public string? SearchString { get; set; } = string.Empty;

		[BindProperty]
		public string StaffId { get; set; }

		public async Task<IActionResult> OnGetAsync(string staffId, string? searchString, int? pageIndex, int? size)
        {
            if (staffId == null) return Page();

			SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
			if (current == null || current.Role == RoleType.Customer)
			{
				httpContextAccessor.HttpContext.Session.Clear();
				return Redirect("/Login");
			}

			if (pageIndex is not null) PageIndex = pageIndex.Value;
			if (size is not null) PageSize = size.Value;
			if (searchString is not null) SearchString = searchString;

			IPaginate<InteriorDto> interior = await interiorService
				.GetPagination(x => x.StaffId.Equals(new Guid(staffId)) && x.Name.Contains(SearchString) && x.IsDeleted.Equals(false), PageIndex, PageSize);

			Interiors = interior.Items;
            TotalPages = interior.TotalPages;

			StaffId = staffId;

			return Page();
        }
		public async Task<IActionResult> OnPostDeleteAsync(string id)
		{
			SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
			if (current == null || current.Role == RoleType.Customer)
			{
				httpContextAccessor.HttpContext.Session.Clear();
				return Redirect("/Login");
			}
			await interiorService.Delete(new Guid(id));
			return Redirect("/Staff/InteriorManagement?staffId="+current.Id);
		}
    }
}
