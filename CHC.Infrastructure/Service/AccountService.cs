using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Account;
using CHC.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CHC.Infrastructure.Service
{
    public class AccountService : BaseService<AccountService>, IAccountService
    {
        public AccountService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<AccountService> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
        {
        }

        public async Task<List<AccountDto>> GetAll()
        {
            ICollection<Account> accounts = await _unitOfWork.GetRepository<Account>().GetListAsync();
            return _mapper.Map<List<AccountDto>>(accounts);
        }

        public async Task<AccountDto> Login(string username, string password)
        {
            Expression<Func<Account, bool>> searchFilter = p =>
                p.Username.Equals(username) &&
                p.Password.Equals(password);
            Account account = await _unitOfWork.GetRepository<Account>()
                 .SingleOrDefaultAsync(predicate: searchFilter);
            return _mapper.Map<AccountDto>(account);
        }
    }   
}
