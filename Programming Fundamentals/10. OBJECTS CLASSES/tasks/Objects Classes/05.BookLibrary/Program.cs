using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Book> books = new List<Book>();

            for (int i = 0; i < n; i++)
            {
                Book currentBook = Book.ReadBook();
                books.Add(currentBook);
            }

            Library library = new Library() { Name = "MyLibrary", Books = books };

            var authorsPrices = new Dictionary<string, decimal>();

            foreach (var book in library.Books)
            {
                if (authorsPrices.ContainsKey(book.Author))
                {
                    authorsPrices[book.Author] += book.Price;
                }
                else
                {
                    authorsPrices.Add(book.Author,book.Price);
                }
            }

            var authorsPricesSorted = authorsPrices.OrderByDescending(x => x.Value).ThenBy(y => y.Key);

            foreach (var pair in authorsPricesSorted)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:F2}");
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

                Book book = new Book() { Title = input[0], Author = input[1], Publisher = input[2], ReleaseDate = bookReleaseDate, ISBN = bookISBN, Price = bookPrice};

                return book;
            }
        }

        class Library
        {
            public string Name { get; set; }
            public List<Book> Books { get; set; }
        }

    }
}
