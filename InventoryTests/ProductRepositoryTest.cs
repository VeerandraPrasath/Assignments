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
        [SetUp]
        public void setup()
        {
            _productList = new List<Product>() { new Product(1, "Prasath", 10, 20) };
            _productRepository = new ProductRepository(_productList);
        }

        [Test]
        public void AddProductShallReturnTrueIfProductAdded()
        {

            var product = new Product(2, "Arun", 5, 10);
            var result = _productRepository.AddProduct(product);
            ClassicAssert.AreEqual(true, result);
        }

        [Test]
        public void GetAllProductsShallReturnProductListIfPresented()
        {
            var result = _productRepository.GetAllProducts();
            ClassicAssert.AreEqual(_productList, result);
        }

        [Test]
        public void IsIdUniqueShallReturnsTrueIfIdUniqueElseFalse()
        {
            var id = 1;
            var expected = false;
            var result = _productRepository.IsIdUnique(id);
            ClassicAssert.AreEqual(expected, result);

            id = 2;
            expected = true;
            result = _productRepository.IsIdUnique(id);
            ClassicAssert.AreEqual(expected, result);
        }

        [Test]
        public void DeleteProductShallReturnTrueIfDeletedElseFalse()
        {
            var expected = false;
            var product = new Product(2, "Arun", 5, 10);
            var result = _productRepository.DeleteProduct(product);
            ClassicAssert.AreEqual(expected, result);

            _productRepository.AddProduct(product);
            expected = true;
            result = _productRepository.DeleteProduct(product);
            ClassicAssert.AreEqual(expected, result);
        }

        [Test]
        public void IsNameUniqueShallReturnsTrueIfIdUniqueElseFalse()
        {
            var name = "Prasath";
            var expected = false;
            var result = _productRepository.IsNameUnique(name);
            ClassicAssert.AreEqual(expected, result);

            name = "Arun";
            expected = true;
            result = _productRepository.IsNameUnique(name);
            ClassicAssert.AreEqual(expected, result);
        }

        [Test]
        public void FindProductShallReturnProductIfPresentElseNull()
        {
            //string input = "5\n\100\nojdad";
            //StringReader  inputReader = new StringReader(input);
            //Console.SetIn(inputReader);

            //StringWriter output = new StringWriter();
            //Console.SetOut(output);
            //string res = output.ToString();

            var result = _productRepository.FindProduct("Prasath");
            ClassicAssert.NotNull(result);

            result = _productRepository.FindProduct("2");
            ClassicAssert.Null(result);
            //ClassicAssert.Contains

        }
    }
}
