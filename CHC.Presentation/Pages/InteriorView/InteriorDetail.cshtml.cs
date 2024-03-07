using CHC.Application.Service;
using CHC.Domain.Dtos.Interior;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages.InteriorView
{
    public class InteriorDetailModel : PageModel
    {
        private IInteriorService interiorService;

        public InteriorDetailModel(IInteriorService interiorService)
        {
            this.interiorService = interiorService;
        }

        [BindProperty(SupportsGet = true)]
        public InteriorDto Interior { get; set; } = default!;

        public async Task<IActionResult> OnGetSync(Guid id)
        {
            Interior = await interiorService.Get(id);
            return Page();
        }
    }
}
