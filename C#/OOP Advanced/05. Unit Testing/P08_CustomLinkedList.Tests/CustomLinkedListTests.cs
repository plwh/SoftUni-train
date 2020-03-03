using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_CustomLinkedList.Tests
{
    [TestFixture]
    public class CustomLinkedListTests
    {
        private DynamicList<string> list;

        [SetUp]
        public void TestInit()
        {
            list = new DynamicList<string>
            {
                "Billie",
                "Jean"
            };
        }

        [Test]
        public void GetElementsCountShouldWork()
        {
            Assert.IsTrue(this.list.Count == 2);
        }

        [Test]
        [TestCase("Jones")]
        public void SetElementAtIndexShouldWork(string item)
        {
            this.list[1] = item;

            Assert.That(this.list[1], Is.EqualTo(item));
        }

        [Test]
        [TestCase("Hello")]
        public void AddMethodShouldWork(string item)
        {
            this.list.Add(item);

            Assert.That(this.list.Count == 3);
        }

        [Test]
        [TestCase("Jean")]
        public void RemoveAtMethodShouldWork(string expected)
        {
            string actual = this.list.RemoveAt(1);

            Assert.IsTrue(actual == expected);
        }

        [Test]
        public void RemoveAtInvalidIndexShouldThrow()
        {
            Assert.That(() => this.list.RemoveAt(2), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase("Billie")]
        public void RemoveElementShouldWork(string elementToRemove)
        {
            this.list.Remove(elementToRemove);

            Assert.That(this.list, Does.Not.Contain(elementToRemove));
        }

        [Test]
        [TestCase("Billie", 0)]
        [TestCase("Jeans", -1)]
        public void RemoveElementShouldReturnCorrectIndex(string item, int expected)
        {
            int actual = this.list.Remove(item);

            Assert.That(actual == expected);
        }

        [Test]
        [TestCase(1)]
        public void IndexOfShouldWork(int expected)
        {
            int actual = this.list.IndexOf("Jean");

            Assert.That(actual == expected);
        }

        [Test]
        [TestCase("Billi")]
        [TestCase("Jeans")]
        public void IndexOfShouldReturnNegativeIndexOnInvalidValue(string element)
        {
            Assert.That(this.list.IndexOf(element), Is.EqualTo(-1));
        }

        [TestCase("Billie", "True")]
        public void ContainsMethodShouldWork(string item, string result)
        {
            Assert.That(this.list.Contains(item).ToString(), Is.EqualTo(result));
        }
    }
}
