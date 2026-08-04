using Microsoft.EntityFrameworkCore;
using StockManagment.Domain.Contracts;
using StockManagment.Domain.Entity;

namespace StockManagment.Infrastructure.Repostory
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQueryable<TEntity, Tkey>
         (
            IQueryable<TEntity> inputQuery,
            ISpecificationRepo<Tkey, TEntity> specifications) where TEntity : BaseEntity<Tkey>
        {
            var query = inputQuery;


            if (specifications.Criteria is not null)
            {
                query = query.Where(specifications.Criteria);
            }



            if (specifications.Includes.Count() > 0)
            {
                query = specifications.Includes.Aggregate(query, (current, include) => current.Include(include));
            }


            if(specifications.OrderBy is not null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }


            if (specifications.OrderByDecending is not null)
            {
                query = query.OrderByDescending(specifications.OrderByDecending);
            }


            if (specifications.IsPagingEnabled)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);

            }

            return query;
        }

    }
}
