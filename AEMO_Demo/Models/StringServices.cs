using System;
using System.Collections.Generic;

namespace AEMO_Demo.Models
{
    public class StringServices
    {

        public IList<int> ReturnMatchingIndexes(string text, string subtext)
        {
            IList<int> returnList = new List<int>();
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(subtext))
            {
                return returnList;
            }

            for (int i = 0; i + subtext.Length <= text.Length; i++)
            {
                if (string.Equals(text.Substring(i, subtext.Length), subtext, StringComparison.OrdinalIgnoreCase))
                {
                    returnList.Add(i);
                }
            }
            return returnList;
        }
    }


    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Product this[string name] { get; }

        void AddProduct(Product product);

        void DeleteProduct(Product product);
    }

    public class Repository : IRepository
    {
        private Dictionary<string, Product> products;
        public Repository()
        {
            products = new Dictionary<string, Product>();
            new List<Product> {
                new Product { Name = "Women Shoes", Price = 99M },
                new Product { Name = "Skirts", Price = 29.99M },
                new Product { Name = "Pants", Price = 40.5M }
            }.ForEach(p => AddProduct(p));
        }

        public IEnumerable<Product> Products => products.Values;
        public Product this[string name] => products[name];
        public void AddProduct(Product product) => products[product.Name] = product;
        public void DeleteProduct(Product product) => products.Remove(product.Name);
    }
}
