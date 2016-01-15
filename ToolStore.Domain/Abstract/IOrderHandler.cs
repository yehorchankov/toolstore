#region

using System.Threading.Tasks;
using ToolStore.DAL.Entities;
using ToolStore.Domain.Entities;

#endregion

namespace ToolStore.Domain.Abstract
{
    /// <summary>
    /// Provides logic to handle order
    /// </summary>
    public interface IOrderHandler
    {
        string Handle(Product product, ShippingDetails shippingCredentials);
    }
}