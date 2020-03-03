using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_IntegrationTests.Tests
{
    [TestFixture]
    public class AppTests
    {
        private Category firstCategory;
        private Category secondCategory;
        private Category thirdCategory;
        private User jack;
        private User josh;
        private App testApp;

        [SetUp]
        public void TestInit()
        {
            firstCategory = new Category("First");
            secondCategory = new Category("Second");
            thirdCategory = new Category("Third");

            jack = new User("Jack");
            josh = new User("Josh");

            testApp = new App();
        }

        [Test]
        public void AddCategoryShouldWork()
        {
            testApp.AddCategory(firstCategory);

            Assert.That(testApp.Categories, Contains.Item(firstCategory));
        }

        [Test]
        public void AddSameCategoryShouldThrow()
        {
            testApp.AddCategory(firstCategory);

            Assert.That(() => testApp.AddCategory(firstCategory), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveCategoryShouldWork()
        {
            testApp.AddCategory(secondCategory);
            testApp.RemoveCategory(secondCategory);

            Assert.That(testApp.Categories, Does.Not.Contain(secondCategory));
        }

        [Test]
        public void RemoveInvalidCategoryShouldThrow()
        {
            testApp.AddCategory(thirdCategory);

            Assert.That(() => testApp.RemoveCategory(firstCategory), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveChildCategoryShouldWork()
        {
            testApp.AddCategory(secondCategory);
            testApp.AddCategory(firstCategory);

            testApp.AssignChildToParentCategory(secondCategory, firstCategory);
            testApp.RemoveCategory(firstCategory);

            Assert.That(secondCategory.Subcategories, Does.Not.Contain(firstCategory));
        }

        [Test]
        public void RemoveParentCategoryShouldAddUsersToItsSubcategories()
        {
            testApp.AddCategory(firstCategory);
            testApp.AddCategory(secondCategory);
            testApp.AddCategory(thirdCategory);

            testApp.AddUser(jack);
            testApp.AddUser(josh);

            testApp.AssignChildToParentCategory(firstCategory, secondCategory);
            testApp.AssignChildToParentCategory(firstCategory, thirdCategory);

            testApp.AssignUserToCategory(firstCategory, jack);
            testApp.AssignUserToCategory(firstCategory, josh);

            testApp.RemoveCategory(firstCategory);

            Assert.That(secondCategory.Users.Count, Is.EqualTo(2));
            Assert.That(thirdCategory.Users.Count, Is.EqualTo(2));
        }

        [Test]
        public void AssignChildToParentCategoryShouldWork()
        {
            testApp.AddCategory(firstCategory);
            testApp.AddCategory(secondCategory);

            testApp.AssignChildToParentCategory(firstCategory, secondCategory);

            Assert.That(testApp.Categories.First().Subcategories, Contains.Item(secondCategory));
        }

        [Test]
        public void AssignChildToInvalidParentCategoryShouldThrow()
        {
            testApp.AddCategory(firstCategory);

            Assert.That(() => testApp.AssignChildToParentCategory(firstCategory, secondCategory), Throws.InvalidOperationException);
        }

        [Test]
        public void AssignChildToNewParentCategoryRemovesChildFromPreviousParent()
        {
            testApp.AddCategory(firstCategory);
            testApp.AddCategory(secondCategory);
            testApp.AddCategory(thirdCategory);

            testApp.AssignChildToParentCategory(firstCategory, secondCategory);
            testApp.AssignChildToParentCategory(thirdCategory, secondCategory);

            Assert.That(testApp.Categories.First().Subcategories.Count, Is.EqualTo(0));
            Assert.That(testApp.Categories.Last().Subcategories.Count, Is.EqualTo(1));
        }

        [Test]
        public void AssignUserToCategoryWorks()
        {
            testApp.AddUser(jack);
            testApp.AddCategory(firstCategory);

            testApp.AssignUserToCategory(firstCategory, jack);

            Assert.That(testApp.Categories.First().Users, Contains.Item(jack));
            Assert.That(testApp.Users.First().Categories, Contains.Item(firstCategory));
        }

        [Test]
        public void AssignInvalidUserToCategoryShouldThrow()
        {
            testApp.AddCategory(firstCategory);

            Assert.That(() => testApp.AssignUserToCategory(firstCategory, jack), Throws.InvalidOperationException);
        }

        [Test]
        public void AssignUserToInvalidCategoryShouldThrow()
        {
            testApp.AddUser(jack);

            Assert.That(() => testApp.AssignUserToCategory(firstCategory, jack), Throws.InvalidOperationException);
        }
    }
}
