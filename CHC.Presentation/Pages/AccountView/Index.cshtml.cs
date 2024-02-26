using CHC.Application.Service;
using CHC.Domain.Dtos.Account;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages.AccountView
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<AccountDto> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Account = await _accountService.GetAll();
        }
    }
}
