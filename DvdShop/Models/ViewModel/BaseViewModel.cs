﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdShop.Models.ViewModel
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Người tạo ")]
        public string CreatedBy { get; set; }
        [Display(Name = "Ngày chỉnh sửa")]
       
        public DateTime? UpdatedDate { get; set; }
        [Display(Name = "Người cập nhật")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}