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
        private IProductRepository _mockProductRepository;
        private Product _product1;
        private Product _product2;

        [SetUp]
        public void setup()
        {
            _product1 = new Product(1, "Prasath", 10, 20);
            _product2 = new Product(2, "Arun", 10, 15);
            _productList = new List<Product>() { _product1, _product2 };
            _mockProductRepository = new ProductRepository();
            _mockProductRepository.AddProduct(_product1);
            _mockProductRepository.AddProduct(_product2);
        }

        [TestCase(3, "Vasanth", 23, 234)]
        [TestCase(4, "Nikil", 23, 22)]
        public void AddProduct_ReturnTrue_When_ProductAdded(int id, string name, int quantity, int price)
        {
            var product = new Product(id, name, price, quantity);

            _mockProductRepository.AddProduct(product);

            ClassicAssert.IsTrue(_mockProductRepository.GetAllProducts().Contains(product));
        }

        [Test]
        public void GetAllProducts_ReturnProductList_When_ProductListExist()
        {
            var result = _mockProductRepository.GetAllProducts();

            ClassicAssert.AreEqual(_productList, result);
        }

        [TestCase(3, true)]
        [TestCase(4, true)]
        public void IsIdUnique_ReturnsTrue_When_IdUnique(int id, bool expected)
        {
            var result = _mockProductRepository.IsIdUnique(id);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase(1, false)]
        [TestCase(2, false)]
        public void IsIdUnique_ReturnsFalse_When_IdNotUnique(int id, bool expected)
        {
            var result = _mockProductRepository.IsIdUnique(id);

            ClassicAssert.AreEqual(expected, result);
        }

        [Test]
        public void DeleteProduct_ReturnTrue_When_ProductDeleted()
        {
            var expected = true;

            var result = _mockProductRepository.DeleteProduct(_product2);

            ClassicAssert.AreEqual(expected, result);
        }


        [TestCase("Nikil", true)]
        [TestCase("Bhai", true)]
        public void IsNameUnique_ReturnsTrue_When_NameIsUnique(string productName, bool expected)
        {
            var result = _mockProductRepository.IsNameUnique(productName);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase("Prasath", false)]
        [TestCase("Arun", false)]
        public void IsNameUnique_ReturnsFalse_When_NameIsNotUnique(string productName, bool expected)
        {
            var result = _mockProductRepository.IsNameUnique(productName);

            ClassicAssert.AreEqual(expected, result);
        }


        [TestCase("Prasath", true)]
        [TestCase("Arun", true)]
        public void FindProduct_ReturnProduct_When_ProductPresent(string productDetail, bool expected)
        {
            var result = _mockProductRepository.FindProduct(productDetail);

            ClassicAssert.AreEqual(result is not null, expected);
        }

        [TestCase("Zyusa", false)]
        [TestCase("Zoyaa", false)]
        public void FindProduct_ReturnNull_When_ProductNotPresent(string productDetail, bool expected)
        {
            var result = _mockProductRepository.FindProduct(productDetail);

            ClassicAssert.AreEqual(result is not null, expected);
        }
    }
}
