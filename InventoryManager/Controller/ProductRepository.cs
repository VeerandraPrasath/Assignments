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

        public bool AddProduct(Product newProduct)
        {
            _productList.Add(newProduct);

            return true;
        }

        public List<Product> GetAllProducts()
        {
            return _productList;
        }

        public bool IsIdUnique(int id)
        {
            foreach (Product product in _productList)
            {
                if (product.Id == id)
                {
                    return false;
                }
            }

            return true;
        }

        public bool DeleteProduct(Product product)
        {
            _productList.Remove(product);

            return true;
        }

        public bool IsNameUnique(string name)
        {
            foreach (Product product in _productList)
            {
                if (product.Name.Equals(name))
                {
                    return false;
                }
            }

            return true;
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