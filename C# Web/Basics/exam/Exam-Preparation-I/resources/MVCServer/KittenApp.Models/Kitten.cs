using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KittenApp.Models
{
    public class Kitten
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        [Range(0, 20)]

        public int Age { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }
    }
}
