using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Web.Models.Data
{
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PublisherId { get; set; }

        public string PublisherName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
