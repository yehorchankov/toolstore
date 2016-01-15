#region

using System;
using System.Linq;
using System.Web.Mvc;
using ToolStore.DAL.Entities;
using ToolStore.Domain.Abstract;
using ToolStore.Domain.Entities;
using ToolStore.UI.Models;

#endregion

namespace ToolStore.UI.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly IOrderHandler _orderHandler;
        private readonly IProductRepository _productRepository;

        public ShipmentController(IOrderHandler orderHandler, IProductRepository repository)
        {
            _orderHandler = orderHandler;
            _productRepository = repository;
        }

        // GET: Shipment
        [HttpGet]
        public ActionResult Buy(int? Id)
        {
            if (Id == null || _productRepository.Products.All(p => p.Id != Id)) 
                return PageNotFound("Item not found");

            var details = new ProductShipmentDetailsViewModel
            {
                Product = _productRepository.Products.FirstOrDefault(p => p.Id == Id),
                ShippingCredentials = new ShippingDetails()
            };

            return View(details);
        }

        [HttpPost]
        public ActionResult Buy(Product product, ProductShipmentDetailsViewModel details)
        {
            details.Product = _productRepository.Products
                .FirstOrDefault(p => p.Id == product.Id);
            if (!ModelState.IsValid)
                return View(details);

            string message = String.Empty;
            if (ModelState.IsValid)
            {
                message = _orderHandler.Handle(details.Product, details.ShippingCredentials);
            }
            return View("Success", (object)message);
        }

        public HttpNotFoundResult PageNotFound(string message)
        {
            return HttpNotFound(message);
        }
    }
}