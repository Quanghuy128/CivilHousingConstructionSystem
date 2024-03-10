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
        public IList<InteriorDto> Interiors { get; set; } = default!;

        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 3;
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;
        public string? SearchString { get; set; } = string.Empty;


        public async Task<IActionResult> OnGetAsync(string? searchString, int? pageIndex, int? size)
        {
            if (pageIndex is not null) PageIndex = pageIndex.Value;
            if (size is not null) PageSize = size.Value;
            if (searchString is not null) SearchString = searchString;

            IPaginate<InteriorDto> interiors = await interiorService.GetPagination(x => x.Name.Contains(SearchString) || x.Description.Contains(SearchString), PageIndex, PageSize);

            Interiors = interiors.Items;
            TotalPages = interiors.TotalPages;
            return Page();
        }

        public async Task<IActionResult> OnPostSearchAsync(string? search = "")
        {
            IPaginate<InteriorDto> interiors = await interiorService.GetPagination(x => x.Name.Contains(search) || x.Description.Contains(search), PageIndex, PageSize);
            Interiors = interiors.Items;
            TotalPages = interiors.TotalPages;
            return Page();
        }
    }
}
