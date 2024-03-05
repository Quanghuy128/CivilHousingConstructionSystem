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

namespace CHC.Presentation.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            this.accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
        }

        public AccountDto Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            SessionUser current = _httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null)
            {
                _httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var account = await accountService.Get(id ?? new Guid());
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
    }
}
