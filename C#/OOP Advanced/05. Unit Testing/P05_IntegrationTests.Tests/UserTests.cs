using NUnit.Framework;

namespace P05_IntegrationTests.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void AssignToCategoryShouldWork()
        {
            var category = new Category("First");
            var targetUser = new User("Pesho");

            targetUser.AssignToCategory(category);

            Assert.That(targetUser.Categories, Contains.Item(category));
        }
    }
}
