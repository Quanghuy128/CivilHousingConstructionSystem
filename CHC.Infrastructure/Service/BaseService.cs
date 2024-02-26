using CHC.Application.Repository;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace CHC.Infrastructure.Service
{
    public class BaseService<T> where T : class
    {
        protected IUnitOfWork<ApplicationDbContext> _unitOfWork;
        protected ILogger<T> _logger;
        protected IMapper _mapper;

        public BaseService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<T> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
