using System.Collections.Generic;

namespace Realmdigital_Interview.Models
{
    public class Product
    {
        public string BarCode { get; set; }
        public string ItemName { get; set; }
        public List<ProductPrices> PriceRecords { get; set; }
    }
}