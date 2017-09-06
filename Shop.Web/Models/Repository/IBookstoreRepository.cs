using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Models.DataContext;
using Shop.Web.Models.Data;
using Shop.Web.Models.Helpers;

namespace Shop.Web.Models.Repository
{
    public interface IBookstoreRepository
    {
        PagedList<Book> GetBooks(BooksResourceParameters booksResourceParameters);
        IEnumerable<CartItem> GetAllCartItems();

        Book GetBookById(int bookId);
        CartItem GetCartItemById(int cartItemId);
        BookType GetTypeById(int typeId);

        void AddCartItem(CartItem cartItem);

        IEnumerable<Storage> GetAllStorages();

        Task<bool> SaveChangesAsync();


    }
}
