using UnitTesting.Entities;

namespace UnitTesting.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int top = 0);
        Product? GetProductById(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
