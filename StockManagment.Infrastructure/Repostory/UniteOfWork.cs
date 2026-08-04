using StockManagment.Domain.Contracts;
using StockManagment.Domain.Entity;
using StockManagment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.Infrastructure.Repostory
{
    public class UniteOfWork(StockManagmentDb context) : IUniteOfWork
    {
        private readonly Dictionary<string, object> _Repos = [];
        public IGenaricRepo<TKey, TEntity> GetRepositor<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName = typeof(TEntity).Name;
            if (_Repos.TryGetValue(typeName, out object OldRepos))
                return (IGenaricRepo<TKey, TEntity>)OldRepos;

            var NewRepo = new GenaricRepo<TKey, TEntity>(context);
            _Repos[typeName] = NewRepo;
            return NewRepo;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await  context.SaveChangesAsync(ct);
        }
    }
}
