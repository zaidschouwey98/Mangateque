using System;
using System.Collections.Generic;

namespace Mangateque.Models
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Mail { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
