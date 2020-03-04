using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleMvc.Domain
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]

        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public User Author { get; set; }
    }
}
