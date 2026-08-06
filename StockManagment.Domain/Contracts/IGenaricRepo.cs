using StockManagment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Domain.Contracts
{
    public interface IGenaricRepo<TKey , TEntity> where TEntity : BaseEntity<TKey>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken Ct);
        Task<TEntity> GetById(TKey id, CancellationToken Ct);
        Task<TEntity> GetByName(Expression<Func<TEntity, bool>> name, CancellationToken Ct);
        Task AddAsync(TEntity entity, CancellationToken Ct);
        void UpdateAsync(TEntity entity, CancellationToken Ct);
        void DeleteAsync(TEntity entity, CancellationToken Ct);
        //Task<IReadOnlyList<TEntity>> GetAllSpecificterAsync(ISpecification<TEntity, TKey> specifications, CancellationToken Ct);
        //Task<TEntity> GetByIdSpecification(ISpecification<TEntity, TKey> specifications, CancellationToken Ct);
        //Task<int> CountOfItemAsync(ISpecification<TEntity, TKey> specifications, CancellationToken Ct);
    }
}
