using InventoryManager.Model;

namespace InventoryManager.Controller
{

    /// <summary>
    /// <see cref="ProductRepository"/> implements <see cref="IProductRepository"/>
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> _productList;

        /// <summary>
        /// <see cref="ProductRepository"/> initialize the <see cref="_productList"/>
        /// </summary>
        public ProductRepository()
        {
            _productList = new List<Product>();
        }
        public bool AddProduct(Product newProduct)
        {
            _productList.Add(newProduct);
            return true;
        }

        public List<Product> GetAllProducts()
        {
            return _productList;
        }

        public bool CheckId(int id)
        {
            foreach (Product product in _productList)
            {
                if (product.Id == id) return true;
            }
            return false;
        }

        public bool DeleteProduct(int id)
        {
            Product productToDelete = FindById(id);
            if (productToDelete != null)
            {
                _productList.Remove(productToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Product FindById(int id)
        {
            foreach (Product product in _productList)
            {
                if (product.Id == id) return product;
            }
            return null;
        }
        public Product GetByName(string name)
        {
            foreach (Product product in _productList)
            {
                if (product.Name.Equals(name)) return product;
            }
            return null;
        }
    }
}