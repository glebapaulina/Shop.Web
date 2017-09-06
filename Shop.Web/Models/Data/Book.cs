using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Models.Data
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookId { get; set; }

        public bool IsOffer { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int BookTypeTypeId { get; set; }
        public string BookTypeTypeName { get; set; }
        public BookType BookType { get; set; }

        public int AuthorAuthorId { get; set; }
        public string AuthorAuthorName { get; set; }
        public Author Author { get; set; }

        public int PublisherPublisherId { get; set; }
        public string PublisherPublisherName { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

    }
}
