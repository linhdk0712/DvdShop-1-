using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DvdShop.Models.Entities
{
    public class Stock:General
    {
        [Display(Name = "Ngày nhập")]
        public DateTime DateInput { get; set; }
        [Display(Name = "Số lượng")]
        public byte Amount { get; set; }
        [Display(Name = "Tồn kho")]
        public int Inventory { get; set; }
        public int IngredientsId { get; set; }
        [ForeignKey(nameof(IngredientsId))]
        public virtual Ingredients Ingredients { get; set; }
    }
}