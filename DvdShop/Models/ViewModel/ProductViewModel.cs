using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdShop.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tên đĩa")]
        public string Name { get; set; }
        [Display(Name = "Ảnh viện")]
        public string StudioName { get; set; }
        [Display(Name = "Ngày nhận")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReceivedDate { get; set; }
        [Display(Name = "Ngày tạo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreate { get; set; }
    }
}