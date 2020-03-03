using System;
using System.Collections.Generic;
using System.Text;

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

    protected virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    protected string Author
    {
        get { return author; }
        set
        {
            string[] authorNames = value.Split();
            if (authorNames.Length > 1)
            {
                if (Char.IsDigit(authorNames[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            author = value;
        }
    }

    protected string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat($@"Type: {this.GetType().Name}
Title: {this.Title}
Author: {this.Author}
Price: {this.Price:f2}");
        return sb.ToString();
    }
}
