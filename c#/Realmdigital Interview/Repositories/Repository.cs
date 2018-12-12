using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Realmdigital_Interview.JsonApi;

namespace Realmdigital_Interview.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected JsonWebServiceClient<TEntity> Context { get; }

        public Repository(JsonWebServiceClient<TEntity> context)
        {
            Context = context;
        }

        public TEntity Get(string id)
        {
            return Context.DownloadProductById(id);
        }

        public IEnumerable<TEntity> GetAllProductById(string productId)
        {
            return Context.DownloadProductsById(productId);
        }

        public IEnumerable<TEntity> GetAllProductByName(string productName)
        {
            return Context.DownloadProductsById(productName);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.DownloadProducts().AsQueryable();
        }
    }
}