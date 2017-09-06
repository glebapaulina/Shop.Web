using System;
using Shop.Web.Models;
using Shop.Web.Models.Data;


namespace Shop.Web.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public bool IsOffer { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int BookTypeTypeId { get; set; }
        public string BookTypeTypeName { get; set; }

        public int AuthorAuthorId { get; set; }
        public string AuthorAuthorName { get; set; }

        public int PublisherPublisherId { get; set; }
        public string PublisherPublisherName { get; set; }

    }
}
