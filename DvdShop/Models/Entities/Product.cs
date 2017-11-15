using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DvdShop.Models.Entities
{
    public class Product: General
    {
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày nhận")]
        public DateTime ReceivedDate { get; set; }
        [Display(Name = "Làm hộp")]
        public bool IsFullBox { get; set; }
        [Display(Name = "Giá thành")]
        public decimal Price { get; set; }
        [MaxLength(500)]
        [DataType("nvarchar")]
        [Display(Name = "Ghi chú")]
        public string Comment { get; set; }
        [Display(Name = "Ảnh viện")]
        public int StudioId { get; set; }
        [ForeignKey(nameof(StudioId))]
        public virtual Studio Studio { get; set; }
       

    }
}