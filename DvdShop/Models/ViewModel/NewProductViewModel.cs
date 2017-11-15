using System.Collections.Generic;
using DvdShop.Models.Entities;

namespace DvdShop.Models.ViewModel
{
    public class NewProductViewModel
    {
        public IEnumerable<Studio> Studios { get; set; }
        public Product Product { get; set; }

    }
}