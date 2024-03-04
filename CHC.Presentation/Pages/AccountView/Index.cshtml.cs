using CHC.Application.Service;
using CHC.Domain.Dtos;
using CHC.Domain.Enums;
using CHC.Domain.Dtos.Account;
using CHC.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages.AccountView
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<AccountDto> Account { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            SessionUser current = _httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Admin)
            {
                _httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }
            Account = await _accountService.GetAll();
            return Page();
        }
    }
}
