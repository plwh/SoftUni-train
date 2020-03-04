﻿using System;
using System.ComponentModel.DataAnnotations;

namespace KittenApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required]

        public string PasswordHash { get; set; }
    }
}
