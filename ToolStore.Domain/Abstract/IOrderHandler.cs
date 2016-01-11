using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToolStore.Domain.Concrete;
using ToolStore.Domain.Entities;

namespace ToolStore.Domain.Abstract
{
    public interface IOrderHandler
    {
        void Handle(Product product, ShippingCredentials shippingCredentials);
    }
}
