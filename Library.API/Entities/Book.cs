using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.API.Entities
{

    [Table("Book")]
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(2500)]
        public string Description { get; set; }


        [ForeignKey("AuthorId")]
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }




    }
}
