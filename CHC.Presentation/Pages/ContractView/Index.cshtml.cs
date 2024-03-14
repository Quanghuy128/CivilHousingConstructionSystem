using CHC.Application.Service;
using CHC.Domain.Dtos;
using CHC.Domain.Dtos.Contract;
using CHC.Domain.Dtos.Quotation;
using CHC.Domain.Enums;
using CHC.Domain.Pagination;
using CHC.Infrastructure.Service;
using CHC.Presentation.Extensions;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages.ContractView
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
        public int PageSize { get; set; } = 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public string? SearchString { get; set; } = string.Empty;
        public bool IsSigned { get; set; } = false;

        public async Task<IActionResult> OnGetAsync(bool isSigned, int? pageIndex, int? size)
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            if (isSigned is true) IsSigned = isSigned;
            if (pageIndex is not null) PageIndex = pageIndex.Value;
            if (size is not null) PageSize = size.Value;

            IPaginate<ContractDto> contacts = await contractService
                .GetPagination(x => x.Content.Contains(SearchString) && x.CustomerId.Equals(current.Id), PageIndex, PageSize);
            Contracts = contacts.Items;
            TotalPages = contacts.TotalPages;
            return Page();
        }

        public async Task<IActionResult> OnPostSignContractAsync(string id)
        {
            ContractDto contract = await contractService.Get(new Guid(id));
            contract.Status = ContractStatus.Assigned;
            await contractService.Update(mapper.Map<UpdateContractRequest>(contract));
            return RedirectToPage("/ContractView/Index", new {isSigned = true});
        }
    }
}
