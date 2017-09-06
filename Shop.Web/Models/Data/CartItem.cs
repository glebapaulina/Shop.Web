using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Models.Data
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        public int BookBookId { get; set; }
        public string BookTitle { get; set; }
        public Book Book { get; set; }

        public string StorageStorageName { get; set; }
        public Storage Storage { get; set; }

        public int Quantity { get; set; }

    }
}
