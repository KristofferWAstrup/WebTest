using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebTest.Infrastructure.Data.Models
{
    public class Product
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<string> ImagePaths { get; set; }

    }
}