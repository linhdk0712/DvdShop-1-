using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdShop.Models.Entities
{
    public class Ingredients : General
    {
        [Display(Name = "Mã nguyên liệu")]
        public string Code { get; set; }
        [Display(Name = "Tên nguyên liệu")]
        public string Name { get; set; }
        [Display(Name = "Giá thành")]
        public decimal Price { get; set; }

        public virtual ICollection<Cost> Cost { get; set; }
    }
}