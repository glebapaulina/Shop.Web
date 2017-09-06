using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Web.Models.Data
{
    public class Storage
    {
        [Key]
        public string StorageName { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
