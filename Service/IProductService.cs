using PokeStore.Model;

namespace PokeStore.Service;

public interface IProductService
{
    IList<Product> FindAllProducts();
    Product FindProduct(int id);
    void AddProduct(Product product);
    void EditProduct(Product product);
    void DeleteProduct(int id);
}
