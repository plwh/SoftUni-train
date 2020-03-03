namespace P04_BubbleSort.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class BubbleSortTests
    {
        private int[] expected;
        private Bubble bubble;

        [SetUp]
        public void TestInit()
        {
            this.expected = new int[] {5, 6, 7, 8, 9 };
        }

        [Test]
        public void SortDefaultOrder()
        {
            int[] arr = new int[] { 7, 5, 6, 9, 8 };
            bubble = new Bubble(arr);

            bubble.Sort();
            Assert.That(bubble.Data, Is.EqualTo(expected));
        }

        [Test]
        public void SortReversedOrder()
        {
            int[] arr = new int[] { 9, 8, 7, 6, 5 };
            bubble = new Bubble(arr);

            bubble.Sort();
            Assert.That(bubble.Data, Is.EqualTo(expected));
        }

        [Test]
        public void SortIncreasingOrder()
        {
            int[] arr = new int[] { 5, 6, 7, 8, 9 };
            bubble = new Bubble(arr);

            bubble.Sort();
            Assert.That(bubble.Data, Is.EqualTo(expected));
        }
    }
}
