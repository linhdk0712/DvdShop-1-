﻿using System;
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
        [Display(Name = "Studio Name")]
        [Required(ErrorMessage = "Studio name is required")]
        public string Name { get; set; }
        [Display(Name = "Skype")]
        public string SkypeName { get; set; }
        [MaxLength(15)]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [MaxLength(15)]
        [Display(Name = "ĐTDĐ")]
        public string MobiNumber { get; set; }
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
        [MaxLength(50)]
        [Display(Name = "Chủ ảnh viện")]
        public string Owner { get; set; }

        public byte Amount { get; set; }
    }
}