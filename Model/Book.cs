using System;
using System.ComponentModel.DataAnnotations;

namespace BookListRazor.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Author { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ISBN { get; set; }
    }
}