using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Shop.Web.Models;
using Shop.Web.Models.Data;

namespace Shop.Web.ViewModels
{
    public class CartItemViewModel
    {
        public int CartItemId { get; set;  }

        public int BookBookId { get; set; }
        public string BookTitle { get; set; }
     
        public string StorageStorageName { get; set; }
        public int Quantity { get; set; }

    }
}
