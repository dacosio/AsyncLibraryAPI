using System;
namespace Library.API.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Author { get; set; } //this will give the first name and last name base on the implentation in booksprofile
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
