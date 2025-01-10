using UnitTesting.Entities;
using UnitTesting.Repositories;

namespace UnitTesting.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product? AddProduct(Product product)
        {
            if (product.Price <= 0)
                throw new ArgumentException("Product price must be greater than zero!");

            return _repository.AddProduct(product);
        }

        public bool Delete(int id)
        {
            return _repository.DeleteProduct(id);
        }

        public Product? GetProductById(int productId)
        {
            return _repository.GetProductById(productId);
        }

        public IEnumerable<Product> GetProducts(int top = 0)
        {
            return _repository.GetProducts(top);
        }

        public Product? Update(Product product)
        {
            return _repository.UpdateProduct(product);
        }
    }
}
