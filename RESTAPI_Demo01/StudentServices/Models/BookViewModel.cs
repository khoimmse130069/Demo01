using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentServices.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Bookname { get; set; }
        public Nullable<double> Bookprice { get; set; }
    }
}