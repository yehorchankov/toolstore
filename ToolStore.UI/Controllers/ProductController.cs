using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolStore.Domain.Abstract;
using ToolStore.Domain.Entities;

namespace ToolStore.UI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_productRepository);
        }

        public ViewResult Details(int Id = 1)
        {
            Product product = _productRepository
                .Products.FirstOrDefault(p => p.Id == Id);
            return View(product);
        }
    }
}