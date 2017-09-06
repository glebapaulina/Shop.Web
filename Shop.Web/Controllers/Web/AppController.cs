using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shop.Web.Models;
using Shop.Web.Models.Repository;

namespace Shop.Web.Controllers.Web
{
    public class AppController : Controller
    {
        private IConfigurationRoot _config;
        private IBookstoreRepository _repository;

        public AppController(IConfigurationRoot config,
            IBookstoreRepository repository)

        {
            _config = config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
