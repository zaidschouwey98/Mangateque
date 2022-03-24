using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mangateque.Models
{
    public partial class Book
    {
        public Book()
        {
            Chapters = new HashSet<Chapter>();
            Types = new HashSet<Type>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string? Name { get; set; }
        public string? Path { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }

        public virtual ICollection<Type> Types { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
