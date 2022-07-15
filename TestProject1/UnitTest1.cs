using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 2, 3)]
        [TestCase(-1, 2, 1)]
        [TestCase(1, -2, -1)]
        [TestCase(-1, -2, -3)]
        public void Sum_WhenAnyAAndB_ShouldSumTwoNumbers
            (int a, int b, int expectedResult)
        {
            Assert.AreEqual(expectedResult, a + b);
        }
    }
}