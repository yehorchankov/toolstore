using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStore.DAL.Entities;

namespace ToolStore.DAL.Abstract
{
    /// <summary>
    /// Provides logic to get data from storage
    /// </summary>
    public interface IDao
    {
        IEnumerable<Product> GetProductsFromFile(string filePath);
    }
}
