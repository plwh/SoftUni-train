namespace P03_IteratorTest.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class IteratorTestTests
    {
        private ListIterator<string> iterator;

        [SetUp]
        public void TestInit()
        {
            this.iterator = new ListIterator<string>(new string[] { "Hi", "Bye", "Dye" });
        }

        [Test]
        public void CreateWithNullParameter()
        {
            Assert.That(() => this.iterator = new ListIterator<string>(null), Throws.ArgumentNullException);
        }

        [Test]
        public void PossibleMove()
        {
            for (int i = 0; i < 2; i++)
            {
                Assert.IsTrue(this.iterator.Move());
            }
        }

        [Test]
        public void ImpossibleMove()
        {
            for (int i = 0; i < 2; i++)
            {
                this.iterator.Move();
            }

            Assert.IsFalse(this.iterator.Move());
        }

        [Test]
        public void ImpossibleMoveWithEmptyList()
        {
            this.iterator = new ListIterator<string>(new string[0]);

            Assert.IsFalse(iterator.Move());
        }

        [Test]
        public void PrintingEmptyListThrows()
        {
            this.iterator = new ListIterator<string>(new string[0]);

            Assert.That(() => iterator.Print(), Throws.InvalidOperationException);
        }

        [Test]
        public void ListHasNextElement()
        {
            Assert.IsTrue(this.iterator.HasNext());
        }

        [Test]
        public void ListDoesNotHaveNextElement()
        {
            for (int i = 0; i < 2; i++)
            {
                this.iterator.Move();
            }

            Assert.IsFalse(this.iterator.HasNext());
        }

        [Test]
        public void EmptyListDoesNotHaveNextElement()
        {
            this.iterator = new ListIterator<string>(new string[0]);

            Assert.IsFalse(this.iterator.HasNext());
        }
    }
}
