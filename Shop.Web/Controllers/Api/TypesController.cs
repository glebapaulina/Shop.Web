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


namespace Shop.Web.Controllers.Api
{
    public class TypesController : Controller
    {
        private IBookstoreRepository _repository;
        private ILogger<TypesController> _logger;

        public TypesController(IBookstoreRepository repository, ILogger<TypesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("api/type/{typeId}")]
        public IActionResult GetTypeById(int typeId)
        {
            try
            {
                var type = _repository.GetTypeById(typeId);
                return Ok(Mapper.Map<BookTypeViewModel>(type));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to load type : {0}", ex);
            }
            return BadRequest("Failed to load type");
        }

        [HttpGet("api/type/{typeId}/books")]
        public IActionResult GetBooksOfType(int typeId)
        {
            try
            {
                var type = _repository.GetTypeById(typeId);
                return Ok(Mapper.Map<IEnumerable<BookViewModel>>(type.Books.ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to load books of type: {0}", ex);
            }
            return BadRequest("Failed to get books of type");
        }




    }
}
