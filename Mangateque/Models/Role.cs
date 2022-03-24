using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mangateque.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
