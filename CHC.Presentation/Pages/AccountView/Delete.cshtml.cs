using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CHC.Domain.Entities;
using CHC.Infrastructure;
using CHC.Application.Service;
using CHC.Domain.Dtos.Account;
using CHC.Domain.Dtos;
using CHC.Domain.Enums;
using CHC.Presentation.Extensions;

namespace CHC.Presentation.Pages.AccountView
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteModel(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public AccountDto Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            SessionUser current = _httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role != RoleType.Admin)
            {
                _httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            AccountDto account = await _accountService.Get(id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool result = await _accountService.Delete(id);
            return RedirectToPage("./Index");
        }
    }
}
