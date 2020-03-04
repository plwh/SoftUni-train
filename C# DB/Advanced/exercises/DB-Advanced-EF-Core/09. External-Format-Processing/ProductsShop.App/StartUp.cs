namespace ProductsShop.App
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Newtonsoft.Json;

    using Data;
    using Models;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            //ResetDatabase();
            GetUsersAndProductsXML();
        }

        //JSON Processing

        //2. Import data
        static string ImportProductsFromJson()
        {
            string path = @"C:\Users\PLWH\Desktop\Coding\C#(SUni)\C# DB\Advanced\exercises\DB-Advanced-EF-Core\09. External-Format-Processing\ProductsShop.App\Files\products.json";

            Random rnd = new Random();

            Product[] products = ImportJson<Product>(path);

            using (var context = new ProductsShopContext())
            {
                int[] userIds = context.Users.Select(u => u.Id).ToArray();

                foreach (var p in products)
                {
                    int index = rnd.Next(0, userIds.Length);
                    int sellerId = userIds[index];

                    int? buyerId = sellerId;
                    while (buyerId == sellerId)
                    {
                        int buyerIndex = rnd.Next(0, userIds.Length);
                        buyerId = userIds[buyerIndex];
                    }

                    if (buyerId - sellerId < 5 && buyerId - sellerId > 0)
                    {
                        buyerId = null;
                    }

                    p.SellerId = sellerId;
                    p.BuyerId = buyerId;
                }

                context.Products.AddRange(products);

                context.SaveChanges();
            }

            return $"{products.Length} products were imported from file: {path}";
        }

        static string ImportCategoriesFromJson()
        {
            string path = @"C:\Users\PLWH\Desktop\Coding\C#(SUni)\C# DB\Advanced\exercises\DB-Advanced-EF-Core\09. External-Format-Processing\ProductsShop.App\Files\categories.json";

            Category[] categories = ImportJson<Category>(path);

            using (var context = new ProductsShopContext())
            {
                context.Categories.AddRange(categories);

                context.SaveChanges();
            }

            return $"{categories.Length} categories were imported from file: {path}";
        }

        static string ImportUsersFromJson()
        {
            string path = @"C:\Users\PLWH\Desktop\Coding\C#(SUni)\C# DB\Advanced\exercises\DB-Advanced-EF-Core\09. External-Format-Processing\ProductsShop.App\Files\users.json";
            User[] users = ImportJson<User>(path);

            using (var context = new ProductsShopContext())
            {
                context.Users.AddRange(users);

                context.SaveChanges();
            }

            return $"{users.Length} users were imported from file: {path}";
        }

        static void SetCategories()
        {
            using (var context = new ProductsShopContext())
            {
                var productIds = context.Products.Select(p => p.Id).ToArray();
                var categoryIds = context.Categories.Select(c => c.Id).ToArray();

                int categoryCount = categoryIds.Length;

                Random rnd = new Random();

                var categoryProducts = new List<CategoryProduct>();

                foreach (var p in productIds)
                {
                    var catProducts = new CategoryProduct[3];

                    for (int i = 0; i < 3; i++)
                    {
                        int index = rnd.Next(0, categoryCount);
                        while (categoryProducts.Any(cp => cp.ProductId == p
                        && cp.CategoryId == categoryIds[index]))
                        {
                            index = rnd.Next(0, categoryCount);
                        }

                        var catPr = new CategoryProduct()
                        {
                            ProductId = p,
                            CategoryId = categoryIds[index]
                        };

                        categoryProducts.Add(catPr);
                    }
                }

                context.CategoryProducts.AddRange(categoryProducts);

                context.SaveChanges();
            }
        }

        static T[] ImportJson<T>(string path)
        {
            string jsonString = File.ReadAllText(path);

            T[] objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }

        //3. Query and Export Data

        //Query 1 - Products In Range
        static void GetProductsInRange()
        {
            using (var context = new ProductsShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                    }).ToArray();

                var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);

                File.WriteAllText("PricesInRange.json", jsonString);
            }
        }

        //Query 2 - Successfully Sold Products
        static void GetSuccessfullySoldProducts()
        {
            using (var context = new ProductsShopContext())
            {
                var users = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        SoldProducts = u.ProductsSold.Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                    }).ToArray();

                var jsonString = JsonConvert.SerializeObject(users, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });

                File.WriteAllText("SuccessfullySoldProducts.json", jsonString);
            }

        }

        //Query 3 - Categories By Products Count
        static void GetCategoriesByProductCount()
        {
            using (var context = new ProductsShopContext())
            {
                var categories = context.Categories
                    .OrderBy(c => c.Name)
                    .Select(c => new
                    {
                        Category = c.Name,
                        ProductsCount = c.CategoryProducts.Select(cp => cp.Product).Count(),
                        AveragePrice = c.CategoryProducts.Select(cp => cp.Product.Price).Average(),
                        TotalRevenue = c.CategoryProducts.Select(cp => cp.Product.Price).Sum()
                    }).ToArray();

                var jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented);

                File.WriteAllText("categories-by-products.json", jsonString);
            }
        }

        //Query 4 - Users and Products
        static void GetUsersAndProducts()
        {
            using (var context = new ProductsShopContext())
            {
                var users = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .OrderByDescending(u => u.ProductsSold.Count())
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        UsersCount = context.Users.Where(cu => cu.ProductsSold.Any(p => p.BuyerId != null)).Count(),
                        Users = context.Users.Select(cu => new
                        {
                            cu.FirstName,
                            cu.LastName,
                            cu.Age,
                            SoldProducts = new {
                                Count = cu.ProductsSold.Count(),
                                Products = cu.ProductsSold
                                    .Select(p => new {
                                        p.Name,
                                        p.Price
                                    })
                            }
                        })
                    });

                var jsonString = JsonConvert.SerializeObject(users, Formatting.Indented, 
                    new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    });

                File.WriteAllText("users-and-products.json", jsonString);
            }
        }

        // XML Processing

        //1.ImportData

        static string ImportUsersFromXml()
        {
            string path = @"C:\Users\PLWH\Desktop\Coding\C#(SUni)\C# DB\Advanced\exercises\DB-Advanced-EF-Core\09. External-Format-Processing\ProductsShop.App\Files\users.xml";

            string xmlString = File.ReadAllText(path);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var users = new List<User>();

            foreach (var e in elements)
            {
                string firstName = e.Attribute("firstName")?.Value;
                string lastName = e.Attribute("lastName").Value;

                int? age = null;
                if (e.Attribute("age") != null)
                {
                    age = int.Parse(e.Attribute("age").Value);
                }

                var user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };

                users.Add(user);
            }

            using (var context = new ProductsShopContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return $"{users.Count} users were imported from file: {path}";
        }

        static string ImportCategoriesFromXml()
        {
            string path = @"C:\Users\PLWH\Desktop\Coding\C#(SUni)\C# DB\Advanced\exercises\DB-Advanced-EF-Core\09. External-Format-Processing\ProductsShop.App\Files\categories.xml";

            string xmlString = File.ReadAllText(path);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var categories = new List<Category>();

            foreach (var e in elements)
            {
                var category = new Category()
                {
                    Name = e.Element("name").Value
                };

                categories.Add(category);
            }

            using (var context = new ProductsShopContext())
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            return $"{categories.Count} categories were imported from file: {path}";
        }

        static string ImportProductsFromXml()
        {
            string path = @"C:\Users\PLWH\Desktop\Coding\C#(SUni)\C# DB\Advanced\exercises\DB-Advanced-EF-Core\09. External-Format-Processing\ProductsShop.App\Files\products.xml";

            string xmlString = File.ReadAllText(path);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();
            var catProducts = new List<CategoryProduct>();

            using (var context = new ProductsShopContext())
            { 
                var userIds = context.Users.Select(u => u.Id).ToArray();
                var categoryIds = context.Categories.Select(u => u.Id).ToArray();

                Random rnd = new Random();

                foreach (var e in elements)
                {
                    string name = e.Element("name").Value;
                    decimal price = decimal.Parse(e.Element("price").Value);

                    int sellerIndex = rnd.Next(0, userIds.Length);
                    int sellerId = userIds[sellerIndex];

                    var product = new Product()
                    {
                        Name = name,
                        Price = price,
                        SellerId = sellerId
                    };

                    int categoryIndex = rnd.Next(0, categoryIds.Length);
                    int categoryId = categoryIds[categoryIndex];

                    var catProduct = new CategoryProduct()
                    {
                        Product = product,
                        CategoryId = categoryId
                    };

                    catProducts.Add(catProduct);
                }

                context.AddRange(catProducts);
                context.SaveChanges();
            }

            return $"{catProducts.Count} products were imported from file: {path}";
        }

        //2. Query and Export Data

        //Query 1 - Products In Range
        static void GetProductsInRangeXML()
        {
            using (var context = new ProductsShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId != null)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                    }).ToArray();

                XDocument xmlDoc = new XDocument();
                xmlDoc.Add(
                        new XElement("products",
                            from p in products
                            select
                                new XElement("product", new XAttribute("name", p.Name), new XAttribute("price", p.Price), new XAttribute("buyer", p.Buyer)))
                    );

                xmlDoc.Save("products-in-range.xml");
            }
        }

        //Query 2 - Sold Products
        static void GetSoldProductsXML()
        {
            using (var context = new ProductsShopContext())
            {
                var users = context.Users
                        .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                        .OrderBy(u => u.LastName)
                        .ThenBy(u => u.FirstName)
                        .Select(u => new
                        {
                            u.FirstName,
                            u.LastName,
                            SoldProducts = u.ProductsSold.Select(p => new
                            {
                                p.Name,
                                p.Price
                            }).ToArray()
                        }).ToArray();

                XDocument xmlDoc = new XDocument();
                xmlDoc.Add(
                        new XElement("users",
                            from u in users
                            select
                                new XElement("user",
                                            u.FirstName != null ? new XAttribute("first-name", u.FirstName) : null,
                                            u.LastName != null ? new XAttribute("last-name", u.LastName) : null,
                                        new XElement("sold-products",
                                                from p in u.SoldProducts
                                                select
                                                    new XElement("product",
                                                        new XElement("name", p.Name),
                                                        new XElement("price", p.Price)
                                                                )
                                                    )
                                            )
                    ));

                xmlDoc.Save("users-sold-products.xml");
            }
        }

        //Query 3 - Categories By Products Count
        static void GetCategoriesByProductCountXML()
        {
            using (var context = new ProductsShopContext())
            {
                var categories = context.Categories
                    .Select(c => new
                    {
                        c.Name,
                        ProductsCount = c.CategoryProducts.Select(cp => cp.Product).Count(),
                        AveragePrice = c.CategoryProducts.Select(cp => cp.Product.Price).Average(),
                        TotalRevenue = c.CategoryProducts.Select(cp => cp.Product.Price).Sum()
                    }).ToArray();

                XDocument xmlDoc = new XDocument();

                xmlDoc.Add(
                    new XElement("categories",
                        from c in categories
                        select
                            new XElement("category", new XAttribute("name", c.Name),
                                        new XElement("products-count", c.ProductsCount),
                                        new XElement("average-price", c.AveragePrice),
                                        new XElement("total-revenue", c.TotalRevenue)
                            )));

                xmlDoc.Save("categories-by-products.xml");
            }
        }

        //Query 4 - Users and Products
        static void GetUsersAndProductsXML()
        {
            using (var context = new ProductsShopContext())
            {
                var users = context.Users
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .OrderByDescending(u => u.ProductsSold.Count())
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        Users = context.Users.Select(cu => new
                        {
                            cu.FirstName,
                            cu.LastName,
                            cu.Age,
                            SoldProducts = new
                            {
                                Products = cu.ProductsSold
                                    .Select(p => new {
                                        p.Name,
                                        p.Price
                                    })
                            }
                        })
                    });

                XDocument xmlDoc = new XDocument();

                xmlDoc.Add(
                        new XElement("users", 
                        new XAttribute("count", users.Count()),  
                        from c in users
                        select
                            from u in c.Users
                            select
                                new XElement("user", 
                                u.FirstName != null ? new XAttribute("first-name", u.FirstName) : null, 
                                new XAttribute("last-name", u.LastName), 
                                u.Age != null ? new XAttribute("age", u.Age) : null,
                                new XElement("sold-products",  
                                            new XAttribute("count", u.SoldProducts.Products.Count()),
                                            from d in u.SoldProducts.Products
                                            select
                                            new XElement("product", 
                                                        new XAttribute("name", d.Name), 
                                                        new XAttribute("price", d.Price)
                                                        )
                                            )
                        )));

                xmlDoc.Save("users-and-products.xml");
            }
        }

        static void ResetDatabase()
        {
            // delete and recreate database
            using (var db = new ProductsShopContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            // fill in necessary data

            ImportUsersFromJson();
            ImportCategoriesFromJson();
            ImportProductsFromJson();
            SetCategories();
        }
    }
}
