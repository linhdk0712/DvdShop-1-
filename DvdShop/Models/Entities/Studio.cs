using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DvdShop.Models.Entities
{
    public class Studio : General
    {
        [MaxLength(30)]
        [DataType("varchar")]
        public string StudioCode { get; set; }

        [MaxLength(250)]
        [DataType("nvarchar")]
        public string Name { get; set; }

        [MaxLength(250)]
        [DataType("varchar")]
        public string SkypeName { get; set; }

        [MaxLength(15)]
        [DataType("varchar")]
        public string PhoneNumber { get; set; }

        [MaxLength(15)]
        [DataType("varchar")]
        public string MobiNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Zalo { get; set; }

        [MaxLength(500)]
        [DataType("nvarchar")]
        public string Address { get; set; }
       
        public decimal Price { get; set; }

        [MaxLength(500)]
        [DataType("nvarchar")]
        public string Comment { get; set; }
        [MaxLength(500)]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [MaxLength(50)]
        [DataType("nvarchar")]
        public string Owner { get; set; }

        public byte Amount { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}