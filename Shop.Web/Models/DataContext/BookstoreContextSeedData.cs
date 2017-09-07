using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Shop.Web.Models.Data;


namespace Shop.Web.Models.DataContext
{
    public class BookstoreContextSeedData
    {
        private BookstoreContext _context;

        
        public BookstoreContextSeedData(BookstoreContext context)
        {
            _context = context;
        }
        
        public async Task EnsureSeedData()
        {
            if(!_context.Books.Any())
            {

               Author puzo =  new Author {AuthorId = 1, AuthorName = "Mario Puzo"};
               Author nabokov = new Author {AuthorId = 2, AuthorName = "Vladimir Nabokov"};
               Author tolkien =  new Author {AuthorId = 4, AuthorName = "J.R.R Tolkien"};
               Author sapkowski =  new Author {AuthorId = 5, AuthorName = "Andrzej Sapkowski"};
               Author martin =  new Author {AuthorId = 6, AuthorName = "George R.R Martin"};
               Author stoker =  new Author {AuthorId = 7, AuthorName = "Bram Stoker"};
               Author kosinski =  new Author {AuthorId = 8, AuthorName = "Jerzy Kosiński"};
                _context.Authors.AddRange(puzo, nabokov , tolkien, sapkowski, martin, stoker, kosinski);


                BookType audiobook = new BookType { TypeId = 1, TypeName = "Audiobook"};
                BookType ebook = new BookType { TypeId = 2, TypeName = "Ebook"};
                _context.BookTypes.AddRange(audiobook, ebook);
               
                
                Publisher albatros = new Publisher {PublisherId = 1, PublisherName = "Albatros"};
                Publisher harperCollins =  new Publisher  {PublisherId = 2, PublisherName = "HarperCollins"};
                Publisher wordsworth = new Publisher { PublisherId = 3, PublisherName = "Wordsworth"};
                Publisher supernowa = new Publisher { PublisherId = 4, PublisherName = "Supernowa" };
                Publisher penguin = new Publisher {PublisherId = 5, PublisherName = "Penguin"};
                _context.Publishers.AddRange(albatros, harperCollins, penguin, supernowa, wordsworth);

                Storage penDrive = new Storage { StorageName = "PenDrive" };
                Storage cd = new Storage { StorageName = "Płyta CD" };
                Storage dvd = new Storage { StorageName = "Płyta DVD" };
                _context.Storages.AddRange(penDrive, cd, dvd);

                var books = new[]
                {
                    new  Book
                    {
                        BookId = 1,
                        Title = "Ojciec Chrzestny",
                        Price = Convert.ToDecimal(39.90),
                        IsOffer = true,
                        ReleaseDate = DateTime.Parse("22.08.2013"),
                        BookType = audiobook,
                        Publisher = albatros,                        
                        Author = puzo
                    },
                    new Book
                    {
                        BookId = 2,
                        Title = "Lolita",
                        Price = Convert.ToDecimal(29.90),
                        IsOffer = true,
                        ReleaseDate = DateTime.Parse("22.10.2015"),
                        BookType = audiobook,
                        Publisher = harperCollins,                       
                        Author = nabokov
                    },
                   
                    new Book
                    {
                        BookId = 3,
                        Title = "Dracula",
                        Price = Convert.ToDecimal(35.90),
                        IsOffer = true,
                        ReleaseDate = DateTime.Parse("08.08.2004"),
                        BookType = audiobook,
                        Publisher = wordsworth,                        
                        Author = stoker
                    },
                    new Book
                    {
                        BookId = 4,
                        Title = "A Game of Thrones",
                        Price = Convert.ToDecimal(69.90),
                        IsOffer = true,
                        ReleaseDate = DateTime.Parse("25.08.2016"),
                        BookType = audiobook,
                        Publisher = harperCollins,                       
                        Author = martin
                    },
                    new Book
                    {
                        BookId = 5,
                        Title = "The Hobbit",
                        Price = Convert.ToDecimal(30.90),
                        IsOffer = false,
                        ReleaseDate = DateTime.Now.AddDays(9),
                        BookType = ebook,
                        Publisher = penguin,                      
                        Author = tolkien
                    },
                    new Book
                    {
                        BookId = 6,
                        Title = "Sezon Burz",
                        Price = Convert.ToDecimal(50.90),
                        IsOffer = false,
                        ReleaseDate = DateTime.Now.AddDays(10),
                        BookType = ebook,
                        Publisher = supernowa,                       
                        Author = sapkowski
                    },
                    new Book
                    {
                        BookId = 7,
                        Title = "Wieża Jaskółki",
                        Price = Convert.ToDecimal(50.90),
                        IsOffer = false,
                        ReleaseDate = DateTime.Now.AddDays(7),
                        BookType = ebook,
                        Publisher = supernowa,                     
                        Author = sapkowski
                    },
                    new Book
                    {
                        BookId = 8,
                        Title = "Pani Jeziora",
                        Price = Convert.ToDecimal(50.90),
                        IsOffer = false,
                        ReleaseDate = DateTime.Now.AddDays(-9),
                        BookType = ebook,
                        Publisher = supernowa,                       
                        Author = sapkowski                       
                    },                    
                    new Book
                    {
                        BookId = 9,
                        Title = "Malowany Ptak",
                        Price = Convert.ToDecimal(39.90),
                        IsOffer = false,
                        ReleaseDate = DateTime.Now.AddDays(-7),
                        BookType = ebook,
                        Publisher = albatros,                      
                        Author = kosinski
                    },

                };
                foreach (Book b in books)
                {
                    _context.Books.Add(b);
                }

                await _context.SaveChangesAsync();
                
            }
           
        }
    }
}
