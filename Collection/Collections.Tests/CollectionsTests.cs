namespace Collections.Tests
{
    public class CollectionsTests
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

        [Test]
        public void Collection_InsertAtMiddle()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");
            names.InsertAt(1, "pesho");

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[jori, pesho, bobi]"));
        }

        [Test]
        public void Collection_InsertAtWithGrow()
        {
            // Arrange
            Collection<int> names = new Collection<int>();
            int initialCapacity = names.Capacity;
            int expectedNewCapacity = names.Capacity * 2;

            // Act
            for (int i = 0; i < names.Capacity; i++)
            {
                names.Add(1);
            }
            names.Add(99);

            // Assert
            Assert.That(names.Count, Is.EqualTo(initialCapacity + 1));
            Assert.That(expectedNewCapacity, Is.EqualTo(initialCapacity * 2));
            Assert.That(names.ToString(), Is.EqualTo("[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 99]"));
        }

        [Test]
        public void Collection_InsertAtInvalidIndex()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");

            // Assert
            Assert.That(() => { names.InsertAt(3, "pesho"); }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => { names.InsertAt(-1, "pesho"); }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Collection_ExchangeMiddle()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi", "pesho");
            names.Exchange(1, 2);

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[jori, pesho, bobi]"));
        }

        [Test]
        public void Collection_ExchangeFirstLast()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi", "pesho");
            names.Exchange(0, 2);

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[pesho, bobi, jori]"));
        }

        [Test]
        public void Collection_ExchangeInvalidIndexes()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");

            // Assert
            Assert.That(() => { names.Exchange(0, 2); }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => { names.Exchange(-1, 2); }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Collection_RemoveAtStart()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi", "pesho");
            names.RemoveAt(0);

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[bobi, pesho]"));
        }

        [Test]
        public void Collection_RemoveAtEnd()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi", "pesho");
            names.RemoveAt(2);

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[jori, bobi]"));
        }

        [Test]
        public void Collection_RemoveAtMiddle()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi", "pesho");
            names.RemoveAt(1);

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[jori, pesho]"));
        }

        [Test]
        public void Collection_RemoveAtInvalidIndex()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi");

            // Assert
            Assert.That(() => { names.RemoveAt(2); }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => { names.RemoveAt(-1); }, Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Collection_RemoveAll()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi", "pesho");
            names.RemoveAt(2);
            names.RemoveAt(1);
            names.RemoveAt(0);

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Collection_Clear()
        {
            // Arrange
            Collection<string> names = new Collection<string>();

            // Act
            names.AddRange("jori", "bobi", "pesho");
            names.Clear();

            // Assert
            Assert.That(names.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Collection_ToStringNestedCollections()
        {
            // Arrange
            Collection<string> names = new("Teddy", "Gerry");
            Collection<int> nums = new(10, 20);
            Collection<DateTime> dates = new();
            Collection<object> nested = new(names, nums, dates);

            // Act
            string nestedString = nested.ToString();

            // Assert
            Assert.That(nestedString, Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));
        }

        [Test]
        [Timeout(1000)]
        public void Collection_1MillionItems()
        {
            // Arrange
            const int itemsCount = 1000000;
            var nums = new Collection<int>();

            // Act
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(nums.Count, Is.EqualTo(itemsCount));
                Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
            });

            // Act
            for (int i = itemsCount - 1; i >= 0; i--)
            {
                nums.RemoveAt(i);
            }

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(nums.ToString(), Is.EqualTo("[]"));
                Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
            });
        }
    }
}