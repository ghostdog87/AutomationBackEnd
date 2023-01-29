namespace Collections.Tests.Tournaments
{
    public class TournamentTests
    {
        [Test]
        public void Collection_EmptyConstructor()
        {
            // Arrange
            Collection<int> nums = new Collection<int>();

            // Act

            // Assert
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Collection_ConstructorSingleItem()
        {
            // Arrange
            Collection<string> names = new Collection<string>("pesho");

            // Act

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[pesho]"));
        }

        [Test]
        public void Collection_ConstructorMultipleItems()
        {
            // Arrange
            Collection<string> names = new Collection<string>("pesho", "gosho");

            // Act

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[pesho, gosho]"));
        }

        [Test]
        public void Collection_Add()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.Add("jori");

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[jori]"));
        }

        [Test]
        public void Collection_AddWithGrow()
        {
            // Arrange
            Collection<int> names = new Collection<int>();
            int initialCapacity = names.Capacity;
            int expectedNewCapacity = names.Capacity * 2;

            // Act
            for (int i = 0; i < names.Capacity; i++)
            {
                names.Add(i);
            }

            // Assert
            Assert.That(names.Count, Is.EqualTo(initialCapacity));
            Assert.That(expectedNewCapacity, Is.EqualTo(initialCapacity * 2));
        }

        [Test]
        public void Collection_AddRange()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[jori, bobi]"));
        }

        [Test]
        public void Collection_GetByIndex()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");
            string name = names[1];

            // Assert
            Assert.That(name, Is.EqualTo("bobi"));
        }

        [Test]
        public void Collection_GetByInvalidIndex()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");

            // Assert
            Assert.That(() => names[2], Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => names[-1], Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Collection_SetByIndex()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");
            names[1] = "pesho";

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[jori, pesho]"));
        }

        [Test]
        public void Collection_SetByInvalidIndex()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");

            // Assert
            Assert.That(() => { names[2] = "pesho"; }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => { names[-1] = "pesho"; }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Collection_AddRangeWithGrow()
        {
            // Arrange
            Collection<int> names = new Collection<int>();
            int initialCapacity = names.Capacity;
            int expectedNewCapacity = names.Capacity * 2;

            // Act
            for (int i = 0; i < names.Capacity / 2; i++)
            {
                names.AddRange(i, i + 1);
            }

            // Assert
            Assert.That(names.Count, Is.EqualTo(initialCapacity));
            Assert.That(expectedNewCapacity, Is.EqualTo(initialCapacity * 2));
        }

        [Test]
        public void Collection_InsertAtStart()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");
            names.InsertAt(0, "pesho");

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[pesho, jori, bobi]"));
        }

        [Test]
        public void Collection_InsertAtEnd()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");
            names.InsertAt(2, "pesho");

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[jori, bobi, pesho]"));
        }
    }
}