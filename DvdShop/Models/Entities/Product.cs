using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DvdShop.Models.Entities
{
    public class Product: General
    {
       
        public string Name { get; set; }
       
        public DateTime ReceivedDate { get; set; }
        
        public bool IsFullBox { get; set; }
       
        public decimal Price { get; set; }
       
      
        public string Comment { get; set; }
       
        public int StudioId { get; set; }
        [ForeignKey(nameof(StudioId))]
        public virtual Studio Studio { get; set; }
       

    }
}