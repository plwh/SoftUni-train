using KittenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KittenApp.Web.Models.ViewModels
{
    public class KittenViewModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string PictureUrl { get; set; } = "https://www.readersdigest.ca/wp-content/uploads/sites/14/2011/01/4-ways-cheer-up-depressed-cat.jpg";

        public static Expression<Func<Kitten, KittenViewModel>> FromKitten =>
            k => new KittenViewModel()
            {
                Name = k.Name,
                Age = k.Age,
                Breed = k.Breed.Name
            };
    }
}
