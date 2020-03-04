﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02_BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public decimal Price
        {
            get { return this.price; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public string Author
        {
            get { return this.author; }
            private set
            {
                string[] authorNames = value.Split();
                if (Char.IsDigit(authorNames[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}" + Environment.NewLine +
                $"Title: {this.Title}" + Environment.NewLine +
                $"Author: {this.Author}" + Environment.NewLine +
                $"Price: {this.Price:f2}";
        }
    }
}
