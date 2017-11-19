using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models.API
{
    public class User
    {
        public Guid id { get; set; }
        public string GivenName { get; set; }
        public string SirName { get; set; }

    }
}