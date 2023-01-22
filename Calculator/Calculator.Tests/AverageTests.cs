namespace Calculator.Tests
{
    [Parallelizable(scope: ParallelScope.All)]
    public class AverageTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Category("Average")]
        public void Calculator_Average_PositiveDecimalResultTest()
        {
            // Arrange
            int[] averageValues = new int[] { 3, 4, 7 };
            double expectedAverage = 4.666666666666667d;

            // Act
            double actualAverage = Calculator.Average(averageValues);

            // Assert
            Assert.That(expectedAverage, Is.EqualTo(actualAverage));
        }

        [Test]
        [Category("Average")]
        public void Calculator_Average_NegativeDecimalResultTest()
        {
            // Arrange
            int[] averageValues = new int[] { -3, -4, -7 };
            double expectedAverage = -4.666666666666667d;

            // Act
            double actualAverage = Calculator.Average(averageValues);

            // Assert
            Assert.That(expectedAverage, Is.EqualTo(actualAverage));
        }
    }
}