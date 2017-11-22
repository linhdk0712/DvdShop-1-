using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DvdShop.Models.Entities;

namespace DvdShop.Models.ViewModel
{
    public class NewProductViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Ngày nhận không được để trống")]
        public DateTime ReceivedDate { get; set; }

        public bool IsFullBox { get; set; }

        public decimal Price { get; set; }

        [MaxLength(500)]
        [DataType("nvarchar")]
         public string Comment { get; set; }

         public int StudioId { get; set; }

    }
}