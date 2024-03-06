using CHC.Application.Repository;
using CHC.Application.Service;
using CHC.Domain.Dtos.Account;
using CHC.Domain.Entities;
using CHC.Domain.Pagination;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CHC.Infrastructure.Service
{
    public class AccountService : BaseService<AccountService>, IAccountService
    {
        public AccountService(IUnitOfWork<ApplicationDbContext> unitOfWork, ILogger<AccountService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<AccountDto> Create(CreateAccountRequest createAccount)
        {
            Account account = _mapper.Map<Account>(createAccount);

            await _unitOfWork.GetRepository<Account>().InsertAsync(account);
            bool isSuccessfull = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessfull) return null!;
            return _mapper.Map<AccountDto>(account);  
        }

        public async Task<bool> Delete(Guid id)
        {
            Account account = _mapper.Map<Account>(await Get(id));
            if (account == null) return false;

            _unitOfWork.GetRepository<Account>().DeleteAsync(account);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public async Task<AccountDto> Get(Guid id)
        {
            Account account = await _unitOfWork.GetRepository<Account>().SingleOrDefaultAsync(predicate: p => p.Id.Equals(id));
            return _mapper.Map<AccountDto>(account);
        }

        public Task<IPaginate<AccountDto>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AccountDto>> GetAll()
        {
            ICollection<Account> accounts = await _unitOfWork.GetRepository<Account>().GetListAsync();
            return _mapper.Map<List<AccountDto>>(accounts);
        }

        public async Task<AccountDto> GetByCondition(Expression<Func<Account, bool>> predicate = null)
        {
            Account account = await _unitOfWork.GetRepository<Account>().SingleOrDefaultAsync(
                predicate: predicate,
                include: x => x.Include(x => x.Quotations)
                ); ;
            return _mapper.Map<AccountDto>(account);
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

        public async Task<bool> Update(UpdateAccountRequest updateAccount)
        {
            Account account = _mapper.Map<Account>(await Get(updateAccount.Id));
            if (account == null) return false;

            account = _mapper.Map<Account>(updateAccount);

            _unitOfWork.GetRepository<Account>().UpdateAsync(account);
            return await _unitOfWork.CommitAsync() > 0;
        }
    }   
}
