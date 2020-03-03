using NUnit.Framework;

namespace P05_IntegrationTests.Tests
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void AssignToParentCategoryShouldWork()
        {
            var parentCategory = new Category("Main");
            var childCategory = new Category("Child");

            childCategory.AssignToParentCategory(parentCategory);

            Assert.That(parentCategory.Subcategories, Contains.Item(childCategory));
        }

        [Test]
        public void RemoveSubcategoryShouldWork()
        {
            var parentCategory = new Category("Main");
            var childCategory = new Category("Child");

            childCategory.AssignToParentCategory(parentCategory);
            parentCategory.RemoveSubcategory(childCategory);

            Assert.That(parentCategory.Subcategories, Does.Not.Contain(childCategory));
        }

        [Test]
        public void AssignUserToCategoryShouldWork()
        {
            var targetCategory = new Category("Target");
            var userToAssign = new User("Josh");

            targetCategory.AssignUserToCategory(userToAssign);

            Assert.That(targetCategory.Users, Contains.Item(userToAssign));
        }
    }
}
