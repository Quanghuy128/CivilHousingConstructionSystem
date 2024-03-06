using CHC.Presentation.DisplayModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHC.Presentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public IList<HomePageModels.Banner> Banners { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            Banners = InitializeBanners();
            return Page();  
        }


        private IList<HomePageModels.Banner> InitializeBanners()
            => new List<HomePageModels.Banner>()
            {
                new HomePageModels.Banner()
                {
                    Title = "Blue Luxury Sofa",
                    Description = "a symbol of relaxation and luxury, meticulously crafted with sumptuous blue upholstery and timeless design. Sink into its plush cushions for unparalleled comfort and elevate your living space with its durability and sophistication.",
                    ImageUrl = "img/banner_img.png"
                },
                new HomePageModels.Banner()
                {
                    Title = "Chair",
                    Description = "a fusion of style and functionality designed to enhance your comfort and elevate your space. With its sleek design and ergonomic features, it provides optimal support while adding a touch of sophistication to any room. Upgrade your seating experience with our Chair, where comfort meets elegance effortlessly.",
                    ImageUrl = "img/product/single-product/product_1.png",
                    ImageSize = 50
                },
                new HomePageModels.Banner()
                {
                    Title = "Living room",
                    Description = "a fusion of style and functionality designed to enhance your comfort and elevate your space. With its sleek design and ergonomic features, it provides optimal support while adding a touch of sophistication to any room. Upgrade your seating experience with our Chair, where comfort meets elegance effortlessly.",
                    ImageUrl = "img/interior/livingroom-banner.jpg",
                    ImageSize = 75
                },
            };
    }
}
