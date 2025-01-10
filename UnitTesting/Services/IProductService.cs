using UnitTesting.Entities;

namespace UnitTesting.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int top=0);
        Product? GetProductById(int productId);
        Product? AddProduct(Product product);
        Product? Update(Product product);
        bool Delete(int id);

    }
}
