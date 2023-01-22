namespace Calculator.Tests
{
    public class SumTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Category("Sum")]
        public void Calculator_Sum_PositiveNumbersTest()
        {
            // Arrange
            int[] sumValues = new int[] {3, 4, 5};
            int expectedSum = 12;

            // Act
            int actualSum = Calculator.Sum(sumValues);

            // Assert
            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }
    }
}