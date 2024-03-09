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
using CHC.Domain.Enums;
using CHC.Presentation.Extensions;
using CHC.Domain.Dtos.Material;

namespace CHC.Presentation.Pages.MaterialView
{
    public class IndexModel : PageModel
    {
        private readonly IMaterialService _materialService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IndexModel(IMaterialService materialService, IHttpContextAccessor httpContextAccessor)
        {
            _materialService = materialService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IList<MaterialDto> Material { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            SessionUser current = _httpContextAccessor.HttpContext!.Session.GetObject<SessionUser>("CurrentUser");
            if (current == null || current.Role == RoleType.Customer)
            {
                _httpContextAccessor.HttpContext.Session.Clear();
                Response.Redirect("/Login");
            }
            Material = await _materialService.GetAll();
            return Page();
        }
    }
}
