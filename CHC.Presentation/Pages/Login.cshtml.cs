using CHC.Application.Service;
using CHC.Domain.Common;
using CHC.Domain.Dtos;
using CHC.Domain.Dtos.Account;
using CHC.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CHC.Presentation.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IAccountService accountService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginModel(
            IConfiguration configuration, 
            IAccountService accountService, 
            IHttpContextAccessor httpContextAccessor)
        {
            this.configuration = configuration;
            this.accountService = accountService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public CreateAccountRequest Account { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Account.Username == AppConfig.Admin.Username && Account.Password == AppConfig.Admin.Password)
            {
                string customerJson = JsonConvert.SerializeObject(new SessionUser
                {
                    Username = Account.Username,
                    DisplayName = Account.Username,
                    Email = Account.Username,
                    Role = RoleType.Admin,
                });
                httpContextAccessor.HttpContext!.Session.Clear();
                httpContextAccessor.HttpContext!.Session.SetString("CurrentUser", customerJson);
                return Redirect("/AccountView/Index");
            }

            AccountDto account = await accountService.Login(Account.Username, Account.Password);

            if (account == null) {
                ErrorMessage = "Account is not existed!!!";
                return Page();
            }
            else
            {
                string customerJson = JsonConvert.SerializeObject(new SessionUser 
                { 
                    Id = account.Id,
                    Username = account.Username,
                    DisplayName= account.FullName,
                    Email = account.Email,
                    Role = account.Role,
                });
                httpContextAccessor.HttpContext!.Session.Clear();
                httpContextAccessor.HttpContext!.Session.SetString("CurrentUser", customerJson);

                return Redirect("/Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Login");
        }
    }
}
