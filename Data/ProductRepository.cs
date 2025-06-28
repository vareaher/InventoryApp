using System.Collections.Generic;
using System.Linq;
using InventoryApp.Models;

namespace InventoryApp.Data
{
    public static class ProductRepository
    {
        private static readonly List<Product> _products = new();

        public static List<Product> GetAll() => _products;

        public static Product GetById(string id) => _products.FirstOrDefault(p => p.ProductID == id);

        public static void Add(Product product)
        {
            if (_products.Any(p => p.ProductID == product.ProductID)) return;
            _products.Add(product);
        }

        public static void Update(string id, int quantityChange)
        {
            var product = GetById(id);
            if (product != null && product.Quantity + quantityChange >= 0)
            {
                product.Quantity += quantityChange;
            }
        }

        public static void Delete(string id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public static List<Product> Search(string name, int? minQty, int? maxQty)
        {
            return _products.Where(p =>
                (string.IsNullOrEmpty(name) || p.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase)) &&
                (!minQty.HasValue || p.Quantity >= minQty) &&
                (!maxQty.HasValue || p.Quantity <= maxQty)
            ).ToList();
        }
    }
}