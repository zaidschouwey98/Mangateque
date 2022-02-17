using System;
using System.Collections.Generic;

namespace Mangateque.Models
{
    public partial class Type
    {
        public Type()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
