using Microsoft.EntityFrameworkCore;
using StockManagment.Domain.Contracts;
using StockManagment.Domain.Entity;
using StockManagment.Infrastructure.Data;
namespace StockManagment.Infrastructure.Repostory
{
    public class GenaricRepo<Tkey , TEntity>(StockManagmentDb context) : IGenaricRepo<Tkey , TEntity> where TEntity : BaseEntity<Tkey>
    {
        public void AddAsync(TEntity entity, CancellationToken Ct)
        {
            context.Set<TEntity>().AddAsync(entity, Ct);
        }

        //public Task<int> CountOfItemAsync(ISpecification<TEntity, Tkey> specifications, CancellationToken Ct)
        //{
        //    return SpecificationEvaluator.GetQueryable<TEntity, Tkey>(context.Set<TEntity>(), specifications).CountAsync();
        //}

        public void DeleteAsync(TEntity entity, CancellationToken Ct)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken Ct)
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync(Ct);
        }

        public Task<TEntity> GetById(Tkey id, CancellationToken Ct)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(TEntity entity, CancellationToken Ct)
        {
            throw new NotImplementedException();
        }
    }
}
