using System;

namespace BookListRazor.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
    }
}