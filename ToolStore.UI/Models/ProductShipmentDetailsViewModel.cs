#region

using ToolStore.DAL.Entities;
using ToolStore.Domain.Entities;

#endregion

namespace ToolStore.UI.Models
{
    /// <summary>
    /// Wrapps <code>Produc</code> and <code>ShippingDetails</code> to use as model
    /// </summary>
    public class ProductShipmentDetailsViewModel
    {
        public Product Product { get; set; }
        public ShippingDetails ShippingCredentials { get; set; }
    }
}