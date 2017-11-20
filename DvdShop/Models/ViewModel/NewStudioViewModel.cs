using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdShop.Models.ViewModel
{
    public class NewStudioViewModel:BaseViewModel
    {
        [MaxLength(30)]
        [Display(Name = "Mã ảnh viện")]
        [Required(ErrorMessage = "Studio Code is required")]
        public string StudioCode { get; set; }
        [MaxLength(250)]
        [Display(Name = "Tên ảnh viện")]
        [Required(ErrorMessage = "Studio name is required")]
        public string Name { get; set; }
        [Display(Name = "Skype")]
        public string SkypeName { get; set; }
        [MaxLength(15)]
        [Display(Name = "Số điện thoại")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public string PhoneNumber { get; set; }
        [MaxLength(15)]
        [Display(Name = "ĐTDĐ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public string MobiNumber { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [MaxLength(50)]
        [Display(Name = "Zalo")]
        public string Zalo { get; set; }
        [MaxLength(500)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Giá thành")]
        public decimal Price { get; set; }
        [MaxLength(500)]
        [Display(Name = "Ghi chú")]
        public string Comment { get; set; }
        [Display(Name = "Ảnh đại diện")]
        [DataType(DataType.Upload)]
        public string Image { get; set; }
        [MaxLength(50)]
        [Display(Name = "Chủ ảnh viện")]
        public string Owner { get; set; }
        [Display(Name = "Số lượng đĩa")]
        public byte Amount { get; set; }
    }
}