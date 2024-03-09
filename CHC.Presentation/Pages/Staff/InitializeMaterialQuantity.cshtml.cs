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
        public string InteriorId { get; set; }
        [BindProperty]
        public string MaterialId { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            SessionUser current = httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role == RoleType.Customer)
            {
                httpContextAccessor.HttpContext.Session.Clear();
                return Redirect("/Login");
            }

            await interiorDetailService.Update(new CreateInterialDetailRequest()
            {
                InteriorId = new Guid(InteriorId),
                MaterialId = new Guid(MaterialId),
                Quantity = Quantity
            });
            return Redirect("/Staff/InteriorManagement?staffId="+current.Id);
        }
    }
}
