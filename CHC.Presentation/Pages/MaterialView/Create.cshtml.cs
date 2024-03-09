using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CHC.Domain.Entities;
using CHC.Infrastructure;
using CHC.Application.Service;
using CHC.Domain.Dtos.Material;

namespace CHC.Presentation.Pages.MaterialView
{
    public class CreateModel : PageModel
    {
        private readonly IMaterialService _materialService;

        public CreateModel(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateMaterialRequest Material { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MaterialDto result = await _materialService.Create(Material);

            return RedirectToPage("./Index");
        }
    }
}
