using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdShop.Models.Entities
{
    public class Studio : General
    {
        [Required(ErrorMessage = "Studio Code is required")]
        [DataType("varchar")]
        [MaxLength(30)]
        [Display(Name = "Mã ảnh viện")]
        public string StudioCode { get; set; }
        [Required(ErrorMessage = "Studio name is required")]
        [Display(Name = "Studio Name")]
        public string Name { get; set; }
        [Display(Name = "Skype")]
        public string SkypeName { get; set; }
        [MaxLength(15)]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "ĐTDĐ")]
        public string MobiNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Zalo")]
        public string Zalo { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Giá thành")]
        public decimal Price { get; set; }
        [Display(Name = "Ghi chú")]
        public string Comment { get; set; }
        [Display(Name = "Chủ ảnh viện")]
        public string Owner { get; set; }

        public byte Amount { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}