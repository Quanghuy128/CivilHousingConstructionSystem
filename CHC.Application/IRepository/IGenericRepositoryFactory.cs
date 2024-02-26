namespace CHC.Application.IService
{
    public interface IGenericRepositoryFactory
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
