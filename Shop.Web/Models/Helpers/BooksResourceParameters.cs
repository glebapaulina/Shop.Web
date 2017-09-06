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


namespace Shop.Web.Models.Helpers
{
    public class BooksResourceParameters
    {
        
        private const int MaxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string BookType { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
    
        public string SearchQuery { get; set; }
    }
}
