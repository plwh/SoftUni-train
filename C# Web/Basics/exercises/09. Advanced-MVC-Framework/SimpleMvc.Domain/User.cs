using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleMvc.Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
