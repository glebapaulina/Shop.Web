using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.Web.Models.Data
{
    public class Author
    {      
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorId { get; set; }   
        public string AuthorName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
