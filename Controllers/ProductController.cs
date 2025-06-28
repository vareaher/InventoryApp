using Microsoft.AspNetCore.Mvc;
using InventoryApp.Models;
using InventoryApp.Data;

namespace InventoryApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string name, int? minQty, int? maxQty)
        {
            var products = ProductRepository.Search(name, minQty, maxQty);
            return View(products);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            ProductRepository.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var product = ProductRepository.GetById(id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost]
        public IActionResult Edit(string id, int quantityChange)
        {
            ProductRepository.Update(id, quantityChange);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var product = ProductRepository.GetById(id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            ProductRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}