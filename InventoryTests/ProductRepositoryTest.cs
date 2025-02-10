using InventoryManager.Controller;
using InventoryManager.Model;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace InventoryManagerTests
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        private List<Product> _productList;
        private IProductRepository _productRepository;
        private Product _product1;
        private Product _product2;

        [SetUp]
        public void setup()
        {
            _product1 = new Product(1, "Prasath", 10, 20);
            _product2 = new Product(2, "Arun", 10, 15);
            _productList = new List<Product>() { _product1, _product2 };
            _productRepository = new ProductRepository();
            _productRepository.AddProduct(_product1);
            _productRepository.AddProduct(_product2);
        }

        [TestCase(3, "Vasanth", 23, 234)]
        [TestCase(4, "Nikil", 23, 22)]
        [Test]
        public void AddProduct_ShallReturnTrue_IfProductAdded(int id, string name, int quantity, int price)
        {
            var product = new Product(id, name, price, quantity);

            _productRepository.AddProduct(product);

            ClassicAssert.IsTrue(_productRepository.GetAllProducts().Contains(product));
        }

        [Test]
        public void GetAllProducts_ShallReturnProductList_IfPresented()
        {
            var result = _productRepository.GetAllProducts();

            ClassicAssert.AreEqual(_productList, result);
        }

        [TestCase(3, true)]
        [TestCase(4, true)]
        [TestCase(1, false)]
        [TestCase(2, false)]
        [Test]
        public void IsIdUnique_ShallReturnsTrue_IfIdUniqueElseFalse(int id, bool expected)
        {
            var result = _productRepository.IsIdUnique(id);

            ClassicAssert.AreEqual(expected, result);
        }


        [Test]
        public void DeleteProduct_ShallReturnTrue_IfProductDeleted()
        {
            var expected = true;

            var result = _productRepository.DeleteProduct(_product2);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase("Prasath", false)]
        [TestCase("Nikil", true)]
        [TestCase("Arun", false)]
        [Test]
        public void IsNameUnique_ShallReturnsTrue_IfIdUniqueElseFalse(string name, bool expected)
        {
            var result = _productRepository.IsNameUnique(name);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase("Prasath", true)]
        [TestCase("Zyusa", false)]
        [Test]
        public void FindProduct_ShallReturnProduct_IfPresentElseNull(string productDetail, bool expected)
        {
            var result = _productRepository.FindProduct(productDetail);

            ClassicAssert.AreEqual(result is not null, expected);
        }
    }
}
