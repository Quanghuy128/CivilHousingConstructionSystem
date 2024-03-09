using CHC.Application.Service;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos.Material;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages.InteriorView
{
    public class InteriorDetailModel : PageModel
    {
        private IInteriorService interiorService;
        private IInteriorDetailService interiorDetailService;

        public InteriorDetailModel(IInteriorService interiorService, IInteriorDetailService interiorDetailService)
        {
            this.interiorService = interiorService;
            this.interiorDetailService = interiorDetailService;
        }

        [BindProperty(SupportsGet = true)]
        public InteriorDto Interior { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public List<InteriorDetailDto> InteriorDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Interior = await interiorService.Get(id);
            return Page();
        }
    }
}
