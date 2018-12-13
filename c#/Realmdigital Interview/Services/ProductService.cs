using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Realmdigital_Interview.Filters;
using Realmdigital_Interview.Models;
using Realmdigital_Interview.Repositories;

namespace Realmdigital_Interview.Services
{
    public interface IProductService
    {
        Product GetProductById(string productId);
        List<Product> GetProductsByName(string productName);
        List<Product> GetProducts();
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductById(string productId)
        {
            return _productRepository.GetProductById(productId, StringConstants.BaseCurrency);
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<Product> GetProductsByName(string productName)
        {
            return _productRepository.GetProducts();
        }
    }
}