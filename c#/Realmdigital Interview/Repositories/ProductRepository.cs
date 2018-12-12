using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Realmdigital_Interview.Filters;
using Realmdigital_Interview.JsonApi;
using Realmdigital_Interview.Models;

namespace Realmdigital_Interview.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(JsonWebServiceClient<Product> context) : base(context)
        {
            
        }
        
        public Product GetProductById(string productId, string currencyCode = StringConstants.BaseCurrency)
        {
            return GetAll().FirstOrDefault(p => p.BarCode == productId);
        }

        public Product GetProductByName(string productName, string currencyCode = StringConstants.BaseCurrency)
        {
            return GetAll().FirstOrDefault(p => p.ItemName == productName);
        }

        public List<Product> GetProducts()
        {
            return GetAll().ToList();
        }
    }
}