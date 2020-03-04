using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KittenApp.Models
{
    public class Breed
    {
        public Breed()
        {
            this.Kittens = new List<Kitten>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        public ICollection<Kitten> Kittens { get; set; }
    }
}
