#region

using System.Collections.Generic;
using ToolStore.DAL.Entities;
using ToolStore.Domain.Entities;

#endregion

namespace ToolStore.Domain.Abstract
{
    /// <summary>
    /// Provides logic to access data
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}