namespace P02_ExtendedDatabase.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using P02_ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase db;

        [SetUp]
        public void TestInit()
        {
            this.db = new ExtendedDatabase(new Person(121215, "John"), new Person(921354876, "Josh"));
        }

        [Test]
        public void AddUser()
        {
            this.db.Add(new Person(10, "Strahil"));

            Assert.AreEqual(3, db.Count);
        }

        [Test]
        public void AddUserWithDuplicateUsername()
        {
            Person person = new Person(121214, "John");

            Assert.That(() => db.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void AddUserWithDuplicatingId()
        {
            Person person = new Person(121215, "Jack");

            Assert.That(() => db.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveUser()
        {
            this.db.Remove();

            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void FindPersonByUsername()
        {
            Person person = db.FindByUsername("John");

            Assert.IsNotNull(person);
        }

        [Test]
        public void FindPersonWithNonExistingUsername()
        {
            Assert.That(() => db.FindByUsername("Jack"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindPesonWithNullValueUsername()
        {
            Assert.That(() => db.FindByUsername(string.Empty), Throws.ArgumentNullException);
        }

        [Test]
        public void FindExistingPersonById()
        {
            Person person = db.FindById(121215);

            Assert.IsNotNull(person);
        }

        [Test]
        public void FindPersonWithNegativeId()
        {
            Assert.That(() => db.FindById(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void FindNonExistingPersonById()
        {
            Assert.That(() => db.FindById(10), Throws.InvalidOperationException);
        }
    }
}
