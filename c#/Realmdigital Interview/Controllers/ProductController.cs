using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Realmdigital_Interview.JsonApi;
using Realmdigital_Interview.Models;
using Realmdigital_Interview.Repositories;
using Realmdigital_Interview.Services;

namespace Realmdigital_Interview.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService; 
        }

        public Product GetProductById(string productId = "item1Id")
        {
            var product = _productService.GetProductById(productId);
            return product;
        }

        public List<Product> GetProductsByName(string productName)
        {
            return _productService.GetProductsByName(productName);
        }
    }
}