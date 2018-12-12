using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Realmdigital_Interview.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAllProductById(string productId);
        IEnumerable<TEntity> GetAllProductByName(string productName);
        IQueryable<TEntity> GetAll();
    }
}