using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToolStore.Domain.Entities;

namespace ToolStore.UI.Models
{
    public class ProductShipmentDetailsViewModel
    {
        public Product Product { get; set; }
        public ShippingCredentials ShippingCredentials { get; set; }
    }
}