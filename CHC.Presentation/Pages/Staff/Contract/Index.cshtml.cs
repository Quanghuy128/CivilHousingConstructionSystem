using CHC.Application.Service;
using CHC.Domain.Dtos;
using CHC.Domain.Dtos.Contract;
using CHC.Domain.Enums;
using CHC.Domain.Pagination;
using CHC.Presentation.Extensions;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace CHC.Presentation.Pages.Staff.Contract
{
    public class IndexModel : PageModel
    {
		private readonly IContractService contractService;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IMapper mapper;

		public IndexModel(IContractService contractService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
		{
			this.contractService = contractService;
			this.httpContextAccessor = httpContextAccessor;
			this.mapper = mapper;
		}

		[BindProperty(SupportsGet = true)]
		public IList<ContractDto> Contracts { get; set; } = new List<ContractDto>();
		public int PageIndex { get; set; } = 1;
		public int TotalPages { get; set; }
		public int PageSize { get; set; } = 10;
		public bool HasNextPage => PageIndex < TotalPages;
		public bool HasPreviousPage => PageIndex > 1;
		public string? SearchString { get; set; } = string.Empty;
		public async Task<IActionResult> OnGetAsync(string? searchString, int? pageIndex, int? size)
		{
			SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
			if (current == null || current.Role == RoleType.Customer)
			{
				httpContextAccessor.HttpContext.Session.Clear();
				return Redirect("/Login");
			}

			if (pageIndex is not null) PageIndex = pageIndex.Value;
			if (size is not null) PageSize = size.Value;
			if (searchString is not null) SearchString = searchString;

			IPaginate<ContractDto> contacts = await contractService
				.GetPagination(x => (x.Content.Contains(SearchString!) || x.Customer.FullName.Contains(SearchString!)) && x.StaffId.Equals(current.Id), PageIndex, PageSize);
			Contracts = contacts.Items;
			TotalPages = contacts.TotalPages;
			return Page();
		}
	}
}
