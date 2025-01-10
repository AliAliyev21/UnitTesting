using UnitTesting.Data;
using UnitTesting.Entities;

namespace UnitTesting.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts(int top = 0)
        {
            if (top > 0)
            {
                return _context.Products.Take(top).ToList();
            }
            return _context.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct == null)
                throw new Exception("Product not found!");

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;

            _context.SaveChanges();
            return existingProduct;
        }
    }
}
