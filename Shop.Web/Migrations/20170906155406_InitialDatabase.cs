using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Web.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    AuthorName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => new { x.AuthorId, x.AuthorName });
                });

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => new { x.TypeId, x.TypeName });
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(nullable: false),
                    PublisherName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => new { x.PublisherId, x.PublisherName });
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageName);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    AuthorAuthorId = table.Column<int>(nullable: false),
                    AuthorAuthorName = table.Column<string>(nullable: true),
                    BookTypeTypeId = table.Column<int>(nullable: false),
                    BookTypeTypeName = table.Column<string>(nullable: true),
                    IsOffer = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PublisherPublisherId = table.Column<int>(nullable: false),
                    PublisherPublisherName = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => new { x.BookId, x.Title });
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorAuthorId_AuthorAuthorName",
                        columns: x => new { x.AuthorAuthorId, x.AuthorAuthorName },
                        principalTable: "Authors",
                        principalColumns: new[] { "AuthorId", "AuthorName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_BookTypes_BookTypeTypeId_BookTypeTypeName",
                        columns: x => new { x.BookTypeTypeId, x.BookTypeTypeName },
                        principalTable: "BookTypes",
                        principalColumns: new[] { "TypeId", "TypeName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherPublisherId_PublisherPublisherName",
                        columns: x => new { x.PublisherPublisherId, x.PublisherPublisherName },
                        principalTable: "Publishers",
                        principalColumns: new[] { "PublisherId", "PublisherName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookBookId = table.Column<int>(nullable: false),
                    BookTitle = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    StorageStorageName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Storages_StorageStorageName",
                        column: x => x.StorageStorageName,
                        principalTable: "Storages",
                        principalColumn: "StorageName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookBookId_BookTitle",
                        columns: x => new { x.BookBookId, x.BookTitle },
                        principalTable: "Books",
                        principalColumns: new[] { "BookId", "Title" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorAuthorId_AuthorAuthorName",
                table: "Books",
                columns: new[] { "AuthorAuthorId", "AuthorAuthorName" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypeTypeId_BookTypeTypeName",
                table: "Books",
                columns: new[] { "BookTypeTypeId", "BookTypeTypeName" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherPublisherId_PublisherPublisherName",
                table: "Books",
                columns: new[] { "PublisherPublisherId", "PublisherPublisherName" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_StorageStorageName",
                table: "CartItems",
                column: "StorageStorageName");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookBookId_BookTitle",
                table: "CartItems",
                columns: new[] { "BookBookId", "BookTitle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
