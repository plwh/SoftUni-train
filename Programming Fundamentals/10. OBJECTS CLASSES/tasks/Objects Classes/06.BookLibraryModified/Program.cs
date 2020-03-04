using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryModified
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var books = new List<Book>();
            

            for (int i = 0; i < n; i++)
            {
                Book currBook = Book.ReadBook();
                books.Add(currBook);
            }

            DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd.MM.yyyy",CultureInfo.InvariantCulture);

            foreach (var book in books.Where(a => a.ReleaseDate > date).OrderBy(a => a.ReleaseDate).ThenBy(a => a.Title))
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
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

            public static Book ReadBook()
            {
                string[] input = Console.ReadLine().Split(' ');

                DateTime bookReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int bookISBN = int.Parse(input[4]);
                decimal bookPrice = decimal.Parse(input[5]);

                Book book = new Book() { Title = input[0], Author = input[1], Publisher = input[2], ReleaseDate = bookReleaseDate, ISBN = bookISBN, Price = bookPrice };

                return book;
            }
        }
    }
}
