using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BookLibraryModified
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../input.txt");
            int n = int.Parse(input[0]);

            List<Book> books = new List<Book>();

            for (int i = 1; i <= n; i++)
            {
                string[] currBookInfo = input[i].Split(' ');

                DateTime bookReleaseDate = DateTime.ParseExact(currBookInfo[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int bookISBN = int.Parse(currBookInfo[4]);
                decimal bookPrice = decimal.Parse(currBookInfo[5]);

                Book currentBook = new Book() { Title = currBookInfo[0], Author = currBookInfo[1], Publisher = currBookInfo[2], ReleaseDate = bookReleaseDate, ISBN = bookISBN, Price = bookPrice };

                books.Add(currentBook);
            }

            DateTime date = DateTime.ParseExact(input[n+1], "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var book in books.Where(a => a.ReleaseDate > date).OrderBy(a => a.ReleaseDate).ThenBy(a => a.Title))
            {
                File.AppendAllText("../../output.txt",$"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}{Environment.NewLine}");
            }
        }

        class Book
        {
            public string Title { get; set; }

            public string Author { get; set; }

            public string Publisher { get; set; }

            public DateTime ReleaseDate { get; set; }

            public int ISBN { get; set; }

            public decimal Price { get; set; }
        }
    }
}
