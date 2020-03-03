namespace P02_ExtendedDatabase
{
    using P01_Database;
    using System;
    using System.Linq;

    public class ExtendedDatabase : Database<Person>
    {
        public ExtendedDatabase() : 
            base() { }

        public ExtendedDatabase(params Person[] values) 
            : base(values) { }

        public Person[] People { get { return this.Fetch(); } }

        public override void Add(Person person)
        {
            if (this.People.Any(p => p.Username == person.Username))
            {
                throw new InvalidOperationException("There is already a user with the same username!");
            }

            if (this.People.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("There is already a user with the same id!");
            }

            base.Add(person);  
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username cannot be null!");
            }

            if (!this.People.Any(p => p.Username == username))
            {
                throw new InvalidOperationException($"User with username {username} does not exist!");
            }

            return this.People.Where(p => p.Username == username).First();
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be a negative number!");
            }

            if (!this.People.Any(p => p.Id == id))
            {
                throw new InvalidOperationException($"User with id {id} does not exist!");
            }

            return this.People.Where(p => p.Id == id).First();
        }
    }
}
