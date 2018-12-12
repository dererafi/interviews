using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Realmdigital_Interview.Controllers;
using Realmdigital_Interview.JsonApi;
using Realmdigital_Interview.Models;
using Realmdigital_Interview.Repositories;
using Realmdigital_Interview.Services;

namespace Realmdigital_Interview.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void TestValidProductObject()
        {
            var productService = new ProductService(new ProductRepository(new JsonWebServiceClient<Product>()));

            ProductController productController = new ProductController(productService);

            var product = productController.GetProductById("item1Id");

            Assert.IsInstanceOfType(product, typeof(Product));
        }
    }
}
