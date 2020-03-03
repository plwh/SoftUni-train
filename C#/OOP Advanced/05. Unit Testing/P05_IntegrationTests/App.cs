﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_IntegrationTests
{
    public class App
    {
        private HashSet<User> users;
        private HashSet<Category> categories;

        public App()
        {
            this.users = new HashSet<User>();
            this.categories = new HashSet<Category>();
        }

        public IReadOnlyCollection<User> Users
        {
            get
            {
                return this.users.ToList().AsReadOnly();
            }
        }

        public IReadOnlyCollection<Category> Categories
        {
            get
            {
                return this.categories.ToList().AsReadOnly();
            }
        }

        public void AddUser(User user)
        {
            this.users.Add(user);
        }

        public void AddCategory(Category category)
        {
            if(this.categories.Any(c=> c.Name == category.Name))
            {
                throw new InvalidOperationException();
            }

            this.categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            if (!this.categories.Any(c => c.Name == category.Name))
            {
                throw new InvalidOperationException();
            }

            foreach (Category item in categories)
            {
                if(item.Subcategories.Contains(category))
                {
                    item.RemoveSubcategory(category);
                }
            }

            if (category.Subcategories.Count > 0)
            {
                foreach (Category subcategory in category.Subcategories)
                {
                    foreach (User user in category.Users)
                    {
                        subcategory.AssignUserToCategory(user);
                        user.AssignToCategory(subcategory);
                    }
                }
            }

            var categoryToRemove = this.categories.Single(c => c.Name == category.Name);
            this.categories.Remove(categoryToRemove);
        }

        public void AssignChildToParentCategory(Category parent, Category child)
        {
            parent = this.categories.SingleOrDefault(c => c.Name == parent.Name);
            child = this.categories.SingleOrDefault(c => c.Name == child.Name);

            if (parent == null || child == null)
            {
                throw new InvalidOperationException();
            }

            foreach (Category category in categories)
            {
                if (category.Subcategories.Contains(child))
                {
                    category.RemoveSubcategory(child);
                }
            }

            child.AssignToParentCategory(parent);
        }

        public void AssignUserToCategory(Category category, User user)
        {
            category = this.categories.SingleOrDefault(c => c.Name == category.Name);

            if(category == null || !this.users.Contains(user))
            {
                throw new InvalidOperationException();
            }

            category.AssignUserToCategory(user);
            user.AssignToCategory(category);
        }
    }
}
