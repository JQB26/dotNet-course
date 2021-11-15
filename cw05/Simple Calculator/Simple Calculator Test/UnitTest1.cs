using NUnit.Framework;
using Simple_Calculator;


namespace Simple_Calculator_Test
{

    [TestFixture]
    public class MyUnitTest
    {
        [Test]
        public void TestRegularUseCaseWithSmallNumbers()
        {
            //Arrange:
            Program simpleCalculator = new();
            //Act:
            var result = simpleCalculator.Add(1, 2);
            //Assert:
            Assert.AreEqual(3, result);
        }
    }
}