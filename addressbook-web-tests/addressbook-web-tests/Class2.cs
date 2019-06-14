using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class TestClasses
    {
        [Test]
        public void TestClass()
        {
            Product product = new Product
            {
                Name = "Apple",
                Expiry = new DateTime(2008, 12, 28),
                Price = 3.99M,
                Sizes = new[] { "Small", "Medium", "Large" }
            };

            string json = JsonConvert.SerializeObject(product, Newtonsoft.Json.Formatting.Indented);
            System.Console.Out.WriteLine(json);

            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
        }
    }

    internal class Product
    {
        public String[] Sizes { get; set; }
        public decimal Price { get; set; }
        public DateTime Expiry { get; set; }
        public string Name { get; set; }
    }
}
