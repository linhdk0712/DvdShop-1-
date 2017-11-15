using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public virtual ICollection<Stock> Stock { get; set; }
    }
}