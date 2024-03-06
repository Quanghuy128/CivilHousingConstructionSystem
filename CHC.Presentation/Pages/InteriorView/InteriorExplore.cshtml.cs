using CHC.Application.Service;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages.InteriorView
{
    public class InteriorExploreModel : PageModel
    {
        private readonly IInteriorService interiorService;

        public InteriorExploreModel(IInteriorService interiorService)
        {
            this.interiorService = interiorService;
        }

        [BindProperty(SupportsGet = true)]
        public IPaginate<InteriorDto> Interiors { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? search, int? page, int? size)
        {
            Interiors = await interiorService.GetPagination(search, page??1, size??10);
            return Page();
        }
    }
}
