#region

using System.Linq;
using System.Web.Mvc;
using ToolStore.DAL.Entities;
using ToolStore.Domain.Abstract;
using ToolStore.Domain.Entities;

#endregion

namespace ToolStore.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_productRepository);
        }

        public ActionResult Details(int? Id)
        {
            if (Id == null || _productRepository.Products.All(p => p.Id != Id))
                return PageNotFound("Item not found");

            Product product = _productRepository
                .Products.FirstOrDefault(p => p.Id == Id);
            return View(product);
        }

        public HttpNotFoundResult PageNotFound(string message)
        {
            return HttpNotFound(message);
        }
    }
}