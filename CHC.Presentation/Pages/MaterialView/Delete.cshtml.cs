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
using CHC.Domain.Dtos;
using CHC.Presentation.Extensions;
using CHC.Domain.Enums;
using CHC.Domain.Dtos.Material;

namespace CHC.Presentation.Pages.MaterialView
{
    public class DeleteModel : PageModel
    {
        private readonly IMaterialService _materialService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteModel(IMaterialService materialService, IHttpContextAccessor httpContextAccessor)
        {
            _materialService = materialService;
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public MaterialDto Material { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            SessionUser current = _httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role == RoleType.Customer)
            {
                _httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            MaterialDto material = await _materialService.Get(id);
            if (material == null)
            {
                return NotFound();
            }
            else
            {
                Material = material;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool result = await _materialService.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
