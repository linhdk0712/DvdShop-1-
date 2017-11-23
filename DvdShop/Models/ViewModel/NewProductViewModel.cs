using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DvdShop.Models.Entities;

namespace DvdShop.Models.ViewModel
{
    public class NewProductViewModel : BaseViewModel
    {
        
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; }
        [Display(Name = "Ngày nhận")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Ngày nhận không được để trống")]
        public DateTime ReceivedDate { get; set; }
        [Display(Name = "Làm hộp")]
        public bool IsFullBox { get; set; }
        [Display(Name = "Giá tiền")]
        public decimal Price { get; set; }
        [Display(Name = "Ghi chú")]
        [MaxLength(500)]
        [DataType("nvarchar")]
         public string Comment { get; set; }
        [Display(Name = "Ảnh viện")]
        public int StudioId { get; set; }

    }
}