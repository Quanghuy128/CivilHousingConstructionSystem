using CHC.Application.Service;
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Dtos;
using CHC.Domain.Entities;
using CHC.Domain.Enums;
using CHC.Domain.Pagination;
using CHC.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MapsterMapper;
using CHC.Domain.Dtos.Contract;

namespace CHC.Presentation.Pages.Staff.Quotation
{
    public class IndexModel : PageModel
    {
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IQuotationService quotationService;
		private readonly IMapper mapper;
		private readonly IContractService contractService;

        public IndexModel(IHttpContextAccessor httpContextAccessor, IQuotationService quotationService, IMapper mapper, IContractService contractService)
		{
			this.httpContextAccessor = httpContextAccessor;
			this.quotationService = quotationService;
			this.mapper = mapper;
			this.contractService = contractService;
		}

		[BindProperty(SupportsGet = true)]
		public IList<QuotationDto> Quotations { get; set; } = new List<QuotationDto>();

		public int PageIndex { get; set; } = 1;
		public int TotalPages { get; set; }
		public int PageSize { get; set; } = 10;
		public bool HasNextPage => PageIndex < TotalPages;
		public bool HasPreviousPage => PageIndex > 1;
		public string? SearchString { get; set; } = string.Empty;
		public string? Message { get; set; } = string.Empty;
		public double TotalPrice { get; set; } = 0;

		public async Task<IActionResult> OnGetAsync(string? message, string? searchString, int? pageIndex, int? size)
		{
			SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
			if (current == null || current.Role == RoleType.Customer)
			{
				httpContextAccessor.HttpContext.Session.Clear();
				return Redirect("/Login");
			}

			if (message is not null) Message = message;
			if (pageIndex is not null) PageIndex = pageIndex.Value;
			if (size is not null) PageSize = size.Value;
			if (searchString is not null) SearchString = searchString;

				IPaginate<QuotationDto> quotations = await quotationService
				.GetPagination(x => x.Content.Contains(SearchString) || x.Interior.Name.Contains(SearchString) || x.Customer.FullName.Contains(SearchString), PageIndex, PageSize);
			Quotations = quotations.Items;
			TotalPages = quotations.TotalPages;

			
			return Page();
		}
		public async Task<IActionResult> OnPostApproveAsync(string id)
		{
			SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
			if (current == null || current.Role == RoleType.Customer)
			{
				httpContextAccessor.HttpContext.Session.Clear();
				return Redirect("/Login");
			}

			QuotationDto quotation = await quotationService.Get(new Guid(id));
			quotation.Status = QuotationStatus.Success;
			await quotationService.Update(mapper.Map<UpdateQuotationRequest>(quotation));

            CreateContractRequest contract = new CreateContractRequest()
			{
				Discount = 0,
				FinalOffer = quotation.EstimatePrice,
				CustomerId = quotation.Customer.Id,
				QuotationId = quotation.Id,
				StaffId = current.Id,
			};
			ContractDto result = await contractService.Create(contract);
			if (result != null) Message = "Created Contract Successfully";

            return RedirectToPage("/Staff/Quotation/Index", new { message = Message});
		}
		public async Task<IActionResult> OnPostRejectAsync(string id)
		{
			QuotationDto quotation = await quotationService.Get(new Guid(id));
			quotation.Status = QuotationStatus.Rejected;
			await quotationService.Update(mapper.Map<UpdateQuotationRequest>(quotation));
			return RedirectToPage("/Staff/Quotation/Index");

		}

	}
}
