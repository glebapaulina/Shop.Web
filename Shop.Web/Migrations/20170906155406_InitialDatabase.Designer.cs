using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Shop.Web.Models.DataContext;

namespace Shop.Web.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20170906155406_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Web.Models.Data.Author", b =>
                {
                    b.Property<int>("AuthorId");

                    b.Property<string>("AuthorName");

                    b.HasKey("AuthorId", "AuthorName");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Shop.Web.Models.Data.Book", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<string>("Title");

                    b.Property<int>("AuthorAuthorId");

                    b.Property<string>("AuthorAuthorName");

                    b.Property<int>("BookTypeTypeId");

                    b.Property<string>("BookTypeTypeName");

                    b.Property<bool>("IsOffer");

                    b.Property<decimal>("Price");

                    b.Property<int>("PublisherPublisherId");

                    b.Property<string>("PublisherPublisherName");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("BookId", "Title");

                    b.HasIndex("AuthorAuthorId", "AuthorAuthorName");

                    b.HasIndex("BookTypeTypeId", "BookTypeTypeName");

                    b.HasIndex("PublisherPublisherId", "PublisherPublisherName");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Shop.Web.Models.Data.BookType", b =>
                {
                    b.Property<int>("TypeId");

                    b.Property<string>("TypeName");

                    b.HasKey("TypeId", "TypeName");

                    b.ToTable("BookTypes");
                });

            modelBuilder.Entity("Shop.Web.Models.Data.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookBookId");

                    b.Property<string>("BookTitle");

                    b.Property<int>("Quantity");

                    b.Property<string>("StorageStorageName");

                    b.HasKey("CartItemId");

                    b.HasIndex("StorageStorageName");

                    b.HasIndex("BookBookId", "BookTitle");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Shop.Web.Models.Data.Publisher", b =>
                {
                    b.Property<int>("PublisherId");

                    b.Property<string>("PublisherName");

                    b.HasKey("PublisherId", "PublisherName");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Shop.Web.Models.Data.Storage", b =>
                {
                    b.Property<string>("StorageName")
                        .ValueGeneratedOnAdd();

                    b.HasKey("StorageName");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Shop.Web.Models.Data.Book", b =>
                {
                    b.HasOne("Shop.Web.Models.Data.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorAuthorId", "AuthorAuthorName");

                    b.HasOne("Shop.Web.Models.Data.BookType", "BookType")
                        .WithMany("Books")
                        .HasForeignKey("BookTypeTypeId", "BookTypeTypeName");

                    b.HasOne("Shop.Web.Models.Data.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherPublisherId", "PublisherPublisherName");
                });

            modelBuilder.Entity("Shop.Web.Models.Data.CartItem", b =>
                {
                    b.HasOne("Shop.Web.Models.Data.Storage", "Storage")
                        .WithMany("CartItems")
                        .HasForeignKey("StorageStorageName");

                    b.HasOne("Shop.Web.Models.Data.Book", "Book")
                        .WithMany("CartItems")
                        .HasForeignKey("BookBookId", "BookTitle");
                });
        }
    }
}
