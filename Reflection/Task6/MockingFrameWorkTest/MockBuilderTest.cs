using NUnit.Framework;
using NUnit.Framework.Legacy;
using Task6;

namespace MockingFrameWorkTest
{
    [TestFixture]
    public class MockBuilderTest
    {
        private MockBuilder _mockBuilder;
        [SetUp]
        public void Setup()
        {
            _mockBuilder = new MockBuilder();
        }

        [Test]
        public void TestDynamicMock()
        {
            Type mockType = _mockBuilder.CreateMock(typeof(IMathOperations));
            var mockInstance = Activator.CreateInstance(mockType);

            int addResult = (int)mockType.GetMethod("Add").Invoke(mockInstance, [ 1, 2 ]);
            int subtractResult = (int)mockType.GetMethod("Subtract").Invoke(mockInstance,[ 5, 3 ]);

            ClassicAssert.AreEqual(0, addResult);
            ClassicAssert.AreEqual(0, subtractResult);
        }
    }
}
