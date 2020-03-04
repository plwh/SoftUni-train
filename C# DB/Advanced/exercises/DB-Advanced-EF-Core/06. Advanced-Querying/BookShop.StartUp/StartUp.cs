namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    class StartUp
    {
        static void Main()
        {
            // string input = Console.ReadLine();
       
            using (var db = new BookShopContext())
            {
                //int number = int.Parse(input);
                //int result = CountBooks(db, number);

                Console.WriteLine(RemoveBooks(db));
            }
        }

        // 1. Golden Books
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            int enumValue = -1;

            switch (command.ToLower())
            {
                case "minor":
                    enumValue = 0;
                    break;
                case "teen":
                    enumValue = 1;
                    break;
                case "adult":
                    enumValue = 2;
                    break;
            }

            string[] titles = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction)enumValue)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            string result = string.Join(Environment.NewLine, titles);

            return result;
        }

        // 2. Books by Price
        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            string result = string.Join(Environment.NewLine, titles);

            return result;
        }

        // 3. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var titles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            string result = string.Join(Environment.NewLine, titles);

            return result;
        }

        // 4. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(new[] { "\t", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string[] titles = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            string result = string.Join(Environment.NewLine, titles);
            return result;
        }

        // 5. Released Before Date-
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var bookInfo = context.Books
                .Where(b => b.ReleaseDate < targetDate)
                .OrderByDescending(b => b.ReleaseDate)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in bookInfo)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return sb.ToString().Trim();
        }

        // 6. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var names = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new 
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var name in names)
            {
                sb.AppendLine(name.FullName);
            }

            return sb.ToString().Trim();
        }

        // 7. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(b => b.Title.Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b);

            string result = string.Join(Environment.NewLine, titles);
            return result;
        }

        // 8. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var bookInfo = context.Books
                .Where(b => b.Author.LastName.StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                });

            StringBuilder sb = new StringBuilder();

            foreach (var book in bookInfo)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().Trim();
        }

        // 9. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books.Where(b => b.Title.Length > lengthCheck).Count();

            return count;
        }

        // 10. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    BookCopies = a.Books.Select(b => b.Copies).Sum()
                }).OrderByDescending(a => a.BookCopies)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.AuthorName} - {author.BookCopies}");
            }

            return sb.ToString().Trim();
        }

        // 11. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryProfitInfo = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Select(b => b.Book.Copies * b.Book.Price).Sum()
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var category in categoryProfitInfo)
            {
                sb.AppendLine($"{category.Name} ${category.Profit}");
            }

            return sb.ToString().Trim();
        }

        // 12. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriesInfo = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    TopBooks = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Select(b => b.Book)
                        .Take(3)
                });

            StringBuilder sb = new StringBuilder();

            foreach (var category in categoriesInfo)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.TopBooks)
                {
                    string year = null;

                    if (book.ReleaseDate == null)
                    {
                        year = "no release date";
                    }
                    else
                    {
                        year = book.ReleaseDate.Value.Year.ToString();
                    }

                    sb.AppendLine($"{book.Title} ({year})");
                }
            }

            return sb.ToString().Trim();
        }

        // 13. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var targetBooks = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in targetBooks)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 14. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            int counter = 0;

            var targetBooks = context.Books
                .Where(b => b.Copies < 4200);

            foreach (var book in targetBooks)
            {
                context.Books.Remove(book);
                counter++;
            }

            context.SaveChanges();

            return counter;
        }
    }
}
