using InventoryManager.Model;

namespace InventoryManager.Controller
{
    /// <summary>
    /// Implements <see cref="IProductRepository"/>
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> _productList;

        /// <summary>
        /// Constructor of Product Repository
        /// </summary>
        public ProductRepository()
        {
            _productList = new List<Product>();
        }

        public void AddProduct(Product newProduct)
        {
            _productList.Add(newProduct);
        }

        public List<Product> GetAllProducts()
        {
            return _productList;
        }

        public bool IsIdUnique(int id)
        {
            Product product = _productList.Find(p => p.Id == id);
            return product != null ? true : false;
        }

        public bool DeleteProduct(Product product)
        {
            _productList.Remove(product);

            return true;
        }

        public bool IsNameUnique(string name)
        {
            Product product = _productList.Find(p => p.Name.Equals(name));
            return product != null ? true : false;
        }

        public Product FindProduct(string productInformation)
        {
            foreach (Product product in _productList)
            {
                if (product.Id.ToString().Equals(productInformation) || product.Name.Equals(productInformation))
                {
                    return product;
                }
            }

            return null;
        }
    }
}