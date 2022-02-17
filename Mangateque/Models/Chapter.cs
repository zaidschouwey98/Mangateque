using System;
using System.Collections.Generic;

namespace Mangateque.Models
{
    public partial class Chapter
    {
        public int Id { get; set; }
        public string? Path { get; set; }
        public int? NumberOfPage { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; } = null!;
    }
}
