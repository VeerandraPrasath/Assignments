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
        public void AddProduct_ReturnTrue_When_ProductAdded(int productId, string productName, int productQuantity, int productPrice)
        {
            var product = new Product(productId, productName, productPrice, productQuantity);

            _mockProductRepository.AddProduct(product);

            ClassicAssert.IsTrue(_mockProductRepository.GetAllProducts().Contains(product));
        }

        [Test]
        public void GetAllProducts_GetAllAvailableProducts_ReturnsProductListIfExist()
        {
            var result = _mockProductRepository.GetAllProducts();

            ClassicAssert.AreEqual(_productList, result);
        }

        [TestCase(3, true)]
        [TestCase(4, true)]
        public void IsIdUnique_ChecksIdIsUnique_ReturnsTrueIfUnique(int productId, bool expected)
        {
            var result = _mockProductRepository.IsIdUnique(productId);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase(1, false)]
        [TestCase(2, false)]
        public void IsIdUnique_ChecksIdIsUnique_ReturnsFalseIfNotUnique(int productId, bool expected)
        {
            var result = _mockProductRepository.IsIdUnique(productId);

            ClassicAssert.AreEqual(expected, result);
        }

        [Test]
        public void DeleteProduct_DeleteProductFromList_ReturnsTrueIfRemoved()
        {
            var expected = true;

            var result = _mockProductRepository.DeleteProduct(_product2);

            ClassicAssert.AreEqual(expected, result);
        }


        [TestCase("Nikil", true)]
        [TestCase("Bhai", true)]
        public void IsNameUnique_ChecksNameIsUnique_ReturnsTrueIfUnique(string productName, bool expected)
        {
            var result = _mockProductRepository.IsNameUnique(productName);

            ClassicAssert.AreEqual(expected, result);
        }

        [TestCase("Prasath", false)]
        [TestCase("Arun", false)]
        public void IsNameUnique_ChecksNameIsUnique_ReturnsFalseIfNotUnique(string productName, bool expected)
        {
            var result = _mockProductRepository.IsNameUnique(productName);

            ClassicAssert.AreEqual(expected, result);
        }


        [TestCase("Prasath", true)]
        [TestCase("Arun", true)]
        public void FindProduct_SearchProductInList_ReturnProductIfExist(string productDetail, bool expected)
        {
            var result = _mockProductRepository.FindProduct(productDetail);

            ClassicAssert.AreEqual(result is not null, expected);
        }

        [TestCase("Zyusa", false)]
        [TestCase("Zoyaa", false)]
        public void FindProduct_SearchProductInList_ReturnNullIfNotExist(string productDetail, bool expected)
        {
            var result = _mockProductRepository.FindProduct(productDetail);

            ClassicAssert.AreEqual(result is not null, expected);
        }
    }
}
