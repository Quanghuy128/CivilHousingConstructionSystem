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
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos;
using CHC.Domain.Enums;
using CHC.Presentation.Extensions;

namespace CHC.Presentation.Pages.Staff
{
    public class InitializeMaterialQuantityModel : PageModel
    {
        private readonly IInteriorDetailService interiorDetailService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public InitializeMaterialQuantityModel(IInteriorDetailService interiorDetailService, IHttpContextAccessor httpContextAccessor)
        {
            this.interiorDetailService = interiorDetailService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IList<InteriorDetailDto> InteriorDetails { get;set; } = default!;
        public string Message { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(string interiorId)
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role == RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }
            InteriorDetails = await interiorDetailService.GetAll(x => x.InteriorId.Equals(new Guid(interiorId)));
            return Page();
        }

        [BindProperty]
        public CreateInterialDetailRequest CreateInterialDetailRequest { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role == RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");  
            }

            await interiorDetailService.Update(CreateInterialDetailRequest);
            return Redirect("/Staff/InitializeMaterialQuantity?interiorId="+ CreateInterialDetailRequest.InteriorId);
		}

        public async Task<IActionResult> OnGetBack()
        {
			SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
			if (current == null || current.Role == RoleType.Customer)
			{
				httpContextAccessor.HttpContext.Session.Clear();
				return Redirect("/Login");
			}
			return Redirect("/Staff/InteriorManagement?staffId="+current.Id);
        }
    }
}
