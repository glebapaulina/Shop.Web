using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Web.Models;
using Shop.Web.Models.Data;
using Shop.Web.Models.DataContext;
using Shop.Web.Models.Repository;
using Shop.Web.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Shop.Web.Models.Helpers;


namespace Shop.Web.Controllers.Api
{
    [Route("api/books/")]
    public class BooksController : Controller
    {
        private IBookstoreRepository _repository;
        private ILogger<BooksController> _logger;
        private IUrlHelper _urlHelper;
        

        public BooksController(IBookstoreRepository repository, ILogger<BooksController> logger, IUrlHelper urlHelper)
        {
            _repository = repository;
            _logger = logger;
            _urlHelper = urlHelper;
        }


        [HttpGet(Name = "GetBooks")]
        public IActionResult GetBooks(BooksResourceParameters booksResourcesParameters)
        {
            try
            {
                var books = _repository.GetBooks(booksResourcesParameters);

                var previousPageLink = books.HasPrevious
                    ? CreateBooksResourceUri(booksResourcesParameters, ResourceUriType.PreviousPage)
                    : null;

                var nextPageLink = books.HasNext
                    ? CreateBooksResourceUri(booksResourcesParameters, ResourceUriType.NextPage)
                    : null;

                var paginationMetadata = new
                {
                    totalCount = books.TotalCount,
                    pageSize = books.PageSize,
                    currentPage = books.CurrentPage,
                    totalPages = books.TotalPages,
                    previousPageLink = previousPageLink,
                    nextPageLink = nextPageLink
                };

                Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

                return Ok(Mapper.Map<IEnumerable<BookViewModel>>(books)); 

            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to load books : {0}", ex);
            }
            return BadRequest("Failed to load books");

        }

        private string CreateBooksResourceUri(
            BooksResourceParameters booksResourceParameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetBooks",
                        new
                        {                      
                            searchQuery = booksResourceParameters.SearchQuery,
                            publisher = booksResourceParameters.Publisher,
                            title = booksResourceParameters.Title,
                            bookType = booksResourceParameters.BookType,
                            pageNumber = booksResourceParameters.PageNumber - 1,
                            pageSize = booksResourceParameters.PageSize
                        });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetBooks",
                        new
                        {                      
                            searchQuery = booksResourceParameters.SearchQuery,
                            publisher = booksResourceParameters.Publisher,
                            title = booksResourceParameters.Title,
                            bookType = booksResourceParameters.BookType,
                            pageNumber = booksResourceParameters.PageNumber + 1,
                            pageSize = booksResourceParameters.PageSize
                        });

                default:
                    return _urlHelper.Link("GetBooks",
                        new
                        {
                            searchQuery = booksResourceParameters.SearchQuery,
                            publisher = booksResourceParameters.Publisher,
                            title = booksResourceParameters.Title,
                            bookType = booksResourceParameters.BookType,
                            pageNumber = booksResourceParameters.PageNumber,
                            pageSize = booksResourceParameters.PageSize
                        });
            }
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            try
            {
                var book = _repository.GetBookById(bookId);
                return Ok(Mapper.Map<BookViewModel>(book));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to load book : {0}", ex);
            }
            return BadRequest("Failed to load book");
        }

    }
}
