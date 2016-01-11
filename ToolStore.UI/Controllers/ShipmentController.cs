using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolStore.Domain.Abstract;
using ToolStore.Domain.Concrete;
using ToolStore.Domain.Entities;
using ToolStore.UI.Models;

namespace ToolStore.UI.Controllers
{
    public class ShipmentController : Controller
    {
        private IOrderHandler _orderHandler;
        private IProductRepository _productRepository;

        public ShipmentController(IOrderHandler orderHandler, IProductRepository repository)
        {
            _orderHandler = orderHandler;
            _productRepository = repository;
        }

        // GET: Shipment
        public ViewResult Buy(int Id)
        {
            ProductShipmentDetailsViewModel details = new ProductShipmentDetailsViewModel
            {
                Product = _productRepository.Products.FirstOrDefault(p => p.Id == Id),
                ShippingCredentials = new ShippingCredentials()
            };
            return View(details);
        }

        [HttpPost]
        public ViewResult Checkout(Product product, ProductShipmentDetailsViewModel details)
        {
            details.Product = _productRepository.Products
                .FirstOrDefault(p => p.Id == product.Id);
            if (!ModelState.IsValid)
                return View("Buy", details);
            if (ModelState.IsValid)
            {
                _orderHandler.Handle(details.Product, details.ShippingCredentials);
            }
            return View("Success");
        }
    }
}