using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Realmdigital_Interview.Filters;
using Realmdigital_Interview.Models;

namespace Realmdigital_Interview.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductById(string productName, string currencyCode);
        Product GetProductByName(string productName, string currencyCode);
        List<Product> GetProducts();
    }
}