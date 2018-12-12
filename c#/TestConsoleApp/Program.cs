using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realmdigital_Interview.JsonApi;
using Realmdigital_Interview.Models;
using Newtonsoft.Json;
using System.IO;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"Realmdigital Interview/JsonFile.txt");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
