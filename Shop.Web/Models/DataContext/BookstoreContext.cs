using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Web.Models.Data;

namespace Shop.Web.Models.DataContext
{
    public class BookstoreContext : DbContext
    {
        private IConfigurationRoot _config;

        public BookstoreContext(IConfigurationRoot config, DbContextOptions options)
            :base(options)
        {
            _config = config;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookType> BookTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:BookstoreContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>()
                .HasKey(a => new {a.AuthorId, a.AuthorName});

            modelBuilder.Entity<Publisher>()
                .HasKey(p => new { p.PublisherId, p.PublisherName });

            modelBuilder.Entity<BookType>()
                .HasKey(t => new { t.TypeId, t.TypeName });

            modelBuilder.Entity<Book>()
                .HasKey(b => new {b.BookId, b.Title});
        }

    }
}
