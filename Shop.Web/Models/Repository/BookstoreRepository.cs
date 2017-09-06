using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Models.Data;
using Shop.Web.Models.DataContext;
using Shop.Web.Models.Helpers;

namespace Shop.Web.Models.Repository
{
    public class BookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext _context;

        public BookstoreRepository(BookstoreContext context)
        {
            _context = context;
        }

        public PagedList<Book> GetBooks(BooksResourceParameters booksResourceParameters)
        {
            var collectionBeforePaging = _context.Books
                .OrderBy(b => b.Title)
                .AsQueryable();

            if (!string.IsNullOrEmpty(booksResourceParameters.BookType))
            {
                var bookTypeForWhereClause = booksResourceParameters.BookType
                    .Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging
                    .Where(b => b.BookTypeTypeName.ToLowerInvariant() == bookTypeForWhereClause);

            }
            if (!string.IsNullOrEmpty(booksResourceParameters.Title))
            {
                var bookTitleForWhereClause = booksResourceParameters.Title
                    .Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging
                    .Where(b => b.Title.Replace(" ", "").ToLowerInvariant() == bookTitleForWhereClause);

            }

            if (!string.IsNullOrEmpty(booksResourceParameters.Publisher))
            {
                var bookPublisherForWhereClause = booksResourceParameters.Publisher
                    .Trim().ToLowerInvariant();
                collectionBeforePaging = collectionBeforePaging
                    .Where(b => b.PublisherPublisherName.Replace(" ", "").ToLowerInvariant() ==
                                bookPublisherForWhereClause);
            }

            if (!string.IsNullOrEmpty(booksResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = booksResourceParameters.SearchQuery
                    .Trim().ToLowerInvariant();

                collectionBeforePaging = collectionBeforePaging
                    .Where(b => b.Title.ToLowerInvariant().Contains(searchQueryForWhereClause) ||
                                b.BookTypeTypeName.ToLowerInvariant().Contains(searchQueryForWhereClause) ||
                                b.PublisherPublisherName.ToLowerInvariant().Contains(searchQueryForWhereClause))
                    .OrderBy(b => b.Title)
                    .ThenBy(b => b.BookTypeTypeName)
                    .ThenBy(b => b.PublisherPublisherName);
            }

            return PagedList<Book>.Create(collectionBeforePaging,
                booksResourceParameters.PageNumber,
                booksResourceParameters.PageSize);

        }

        public Book GetBookById(int bookId)
        {
            return _context.Books
              .FirstOrDefault(b => b.BookId == bookId);
        }
     
             
        public IEnumerable<CartItem> GetAllCartItems()
        {
            return _context.CartItems.ToList();
        }

        public CartItem GetCartItemById(int cartItemId)
        {
            return _context.CartItems
                .FirstOrDefault(c => c.CartItemId == cartItemId);
        }

     
        public BookType GetTypeById(int typeId)
            {
                return _context.BookTypes
                    .Include(b => b.Books)
                    .FirstOrDefault(b => b.TypeId == typeId);
            }
    
        public void AddCartItem(CartItem cartItem)
        {
            _context.Add(cartItem);
          
        }
      
        public IEnumerable<Storage> GetAllStorages()
        {

            return _context.Storages.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
