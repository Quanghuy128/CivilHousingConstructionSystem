using CHC.Application.Repository;
using CHC.Domain.Dtos.Account;
using CHC.Domain.Enums;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CHC.Infrastructure.Service
{
    public class BaseService<T> where T : class
    {
        protected readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        protected readonly ILogger<T> _logger;
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<T> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private const string AUTH_KEY = "auth";

        protected AccountDto GetAuthentication()
        {
            var userJson = _httpContextAccessor.HttpContext.Session.GetString(AUTH_KEY);
            if (userJson is null) throw new UnauthorizedAccessException("Not Authenticated");
            return JsonConvert.DeserializeObject<AccountDto>(userJson) ?? null!;
        }

        protected void SetAuthentication(AccountDto account)
        {
            string userJson = JsonConvert.SerializeObject(account);
            _httpContextAccessor.HttpContext.Session.SetString(AUTH_KEY, userJson);
        }

        protected RoleType GetRole()
        {
            var userJson = _httpContextAccessor.HttpContext.Session.GetString(AUTH_KEY);
            if (userJson is null) throw new UnauthorizedAccessException("Not Authenticated");
            return JsonConvert.DeserializeObject<AccountDto>(userJson).Role;
        }
    }
}
