using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mangateque.Models
{
    public partial class Type
    {
        public Type()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
