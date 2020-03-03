namespace P01_Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using P01_Database;

    public class DatabaseTests
    {
        private int[] array;
        private int[] bigArray;
        private int[] limitArray;

        [SetUp]
        public void TestInit()
        {
            this.array = Enumerable.Range(1, 5).ToArray();
            this.bigArray = Enumerable.Range(1, 17).ToArray();
            this.limitArray = Enumerable.Range(1, 16).ToArray();
        }

        [Test]
        public void ConstructorShouldInitializeArrayAccurately()
        {
            var db = new Database<int>(array);

            int[] actual = db.Fetch();

            Assert.That(actual, Is.EqualTo(array));
        }

        [Test]
        public void ConstructorShouldThrowWithManyelements()
        {
            Assert.That(() => new Database<int>(bigArray), Throws.InvalidOperationException);
        }

        [Test]
        public void AddShouldAddElement()
        {
            var db = new Database<int>(array);

            db.Add(6);

            int[] expected = array.Concat(new int[] { 6 }).ToArray();
            int[] actual = db.Fetch();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddShouldThrowWhenEndIsReached()
        {
            var db = new Database<int>(limitArray);

            Assert.That(() => db.Add(17), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldRemoveLastElement()
        {
            var db = new Database<int>(array);

            int actual = db.Remove();
            int expected = array.Last();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveEmptyCollectionShouldThrow()
        {
            var db = new Database<int>();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void ComplexFunctionalityTest()
        {
            var db = new Database<int>(array);
            db.Remove();
            db.Remove();
            db.Remove();
            db.Add(13);
            db.Add(14);
            db.Remove();

            var expected = new int[] { 1, 2, 13 };
            var actual = db.Fetch();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
