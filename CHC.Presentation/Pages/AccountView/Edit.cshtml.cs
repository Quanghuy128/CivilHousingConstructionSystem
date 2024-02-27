using CHC.Application.Service;
using CHC.Domain.Dtos.Account;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CHC.Presentation.Pages.AccountView
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public EditModel(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [BindProperty]
        public UpdateAccountRequest Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _accountService.Get(id);
            if (account == null)
            {
                return NotFound();
            }
            Account = _mapper.Map<UpdateAccountRequest>(account);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _accountService.Update(Account);

            return RedirectToPage("./Index");
        }

    }
}
