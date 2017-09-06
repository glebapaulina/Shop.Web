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
    public class StoragesController : Controller
    {
        private IBookstoreRepository _repository;
        private ILogger<StoragesController> _logger;

        public StoragesController(IBookstoreRepository repository, ILogger<StoragesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet("api/storages")]
        public IActionResult GetAllStorages()
        {
            try
            {
                var storages = _repository.GetAllStorages();
                return Ok(Mapper.Map<IEnumerable<StorageViewModel>>(storages));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to load storages : {0}", ex);
            }
            return BadRequest("Failed to load storages");
        }

       


    }
}
