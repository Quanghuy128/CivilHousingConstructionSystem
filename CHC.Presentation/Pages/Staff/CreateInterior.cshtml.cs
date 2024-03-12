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
using CHC.Domain.Dtos;
using CHC.Domain.Enums;
using CHC.Presentation.Extensions;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.InteriorDetail;
using MapsterMapper;

namespace CHC.Presentation.Pages.Staff
{
    public class CreateInteriorModel : PageModel
    {
        private readonly IInteriorService interiorService;
        private readonly IMaterialService materialService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IInteriorDetailService interiorDetailService;
        private readonly IMapper mapper;

		public CreateInteriorModel(IInteriorService interiorService, IMaterialService materialService, IHttpContextAccessor httpContextAccessor, IInteriorDetailService interiorDetailService, IMapper mapper)
		{
			this.interiorService = interiorService;
			this.materialService = materialService;
			this.httpContextAccessor = httpContextAccessor;
            this.interiorDetailService = interiorDetailService;
            this.mapper = mapper;
		}

		public async Task<IActionResult> OnGetAsync()
        {
			SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
			if (current == null || current.Role == RoleType.Customer)
			{
				httpContextAccessor.HttpContext.Session.Clear();
				return Redirect("/Login");
			}

            ViewData["MaterialId"] = new SelectList(await materialService.GetAll(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CreateInteriorRequest Interior { get; set; } = default!;
        public string InteriorId { get; set; } = default!;
        public string ErrorMessage { get; set; } = default!;
        public string SuccessMessage { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] materialIds)
        {
			SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
			if (current == null || current.Role == RoleType.Customer)
			{
				httpContextAccessor.HttpContext.Session.Clear();
				return Redirect("/Login");
			}

			if (!ModelState.IsValid)
            {
                return Page();
            }

            Interior.StaffId = current.Id;
            foreach (var id in materialIds)
            {
                Interior.TotalPrice += (await materialService.GetOneByCondition(x => x.Id.Equals(new Guid(id)))).Price;
            }
            InteriorDto interior = await interiorService.Create(Interior);

            List<InteriorDetailDto> details = new List<InteriorDetailDto>();

            foreach (var id in materialIds)
            {
                details.Add(new InteriorDetailDto()
                {
                    InteriorId = interior.Id,
                    MaterialId = new Guid(id),
                    Material = (await materialService.GetOneByCondition(x => x.Id.Equals(new Guid(id)))),
                    Quantity = 1,
                });
            }
            bool result = await interiorDetailService.AddRange(details);

            if (!result)
            {
                ErrorMessage = "Created Failed";
            }
            InteriorId = interior.Id.ToString();
            SuccessMessage = "Created Successfully";
            return Page();
        }
    }
}
