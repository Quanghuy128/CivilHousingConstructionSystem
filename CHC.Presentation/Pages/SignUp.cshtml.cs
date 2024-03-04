using CHC.Application.Service;
using CHC.Domain.Dtos.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IAccountService accountService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SignUpModel(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            this.accountService = accountService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [BindProperty(SupportsGet = true)]
        public CreateAccountRequest Account { get; set; } = default!;
        [BindProperty]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();

            if (Account.Password != ConfirmPassword) ErrorMessage = "Password is not matched !!!\n";
            if (await CheckDuplicatedUsernameOrEmail(Account.Username, Account.Email)) ErrorMessage = "Account is duplicated !!!\n";

            if (ErrorMessage != string.Empty) return Page();

            if((await accountService.Create(Account)) is null)
            {
                ErrorMessage = "Failed To Create!!!";
                return Page();
            }
            
             return Redirect("/Login");
        }

        private async Task<bool> CheckDuplicatedUsernameOrEmail(string username, string email)
           => await accountService.GetByCondition(x => x.Username.Equals(username) || x.Email.Equals(email)) is not null;
    }
}
