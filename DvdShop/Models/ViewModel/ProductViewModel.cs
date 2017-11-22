using System;
using System.ComponentModel.DataAnnotations;

namespace DvdShop.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tên đĩa")]
        public string Name { get; set; }
        [Display(Name = "Ảnh viện")]
        public string StudioName { get; set; }
        [Display(Name = "Làm hộp")]
        public bool IsFullBox { get; set; }
        [Display(Name = "Giá thành")]
        public decimal Price { get; set; }
        [MaxLength(500)]
        [DataType("nvarchar")]
        [Display(Name = "Ghi chú")]
        public string Comment { get; set; }
        [Display(Name = "Ngày nhận")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReceivedDate { get; set; }
        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }
    }
}