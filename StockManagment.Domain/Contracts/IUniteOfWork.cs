using StockManagment.Domain.Entity;


namespace StockManagment.Domain.Contracts
{
    public interface IUniteOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);

        IGenaricRepo<TKey, TEntity> GetRepositor<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
