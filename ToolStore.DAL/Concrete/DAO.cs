using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ToolStore.DAL.Abstract;
using ToolStore.DAL.Entities;

namespace ToolStore.DAL.Concrete
{
    /// <summary>
    /// Implements IDao
    /// </summary>
    public class Dao : IDao
    {
        /// <summary>
        /// Gets data from local storage
        /// </summary>
        /// <param name="filePath">Path to file on disk</param>
        /// <returns>Collection of <code>Products</code></returns>
        public IEnumerable<Product> GetProductsFromFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            List<Product> products = new List<Product>();
            string data = reader.ReadToEnd();
            string productInfo = String.Empty;
            int nextIndex = 0;

            while (nextIndex != data.Length - 1)
            {
                var prevIndex = nextIndex;
                nextIndex = data.IndexOf('@', nextIndex + 1);
                productInfo = data.Substring(prevIndex, nextIndex);
                
                Regex dataMatcher = new Regex(
                    "(?<id>[\\d]+)___(?<name>[\\s\\S]+)___(?<desc>[\\s\\S]+)___(?<price>[\\d]+\\.[\\d]+)");
                var c = dataMatcher.Match(productInfo);

                var product = new Product
                {
                    Id = Convert.ToInt32(c.Groups["id"].Value),
                    Description = c.Groups["desc"].Value,
                    Name = c.Groups["name"].Value,
                    Price = Convert.ToDecimal(c.Groups["price"].Value)
                };
                
                products.Add(product);
            }

            return products;
        }
    }
}
