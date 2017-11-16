using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdShop.Models.Entities
{
    public class User:General
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}