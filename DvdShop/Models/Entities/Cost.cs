using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DvdShop.Models.Entities
{
    public class Cost:General
    {
        public int IngredientsId { get; set; }
        public byte Amount { get; set; }
        [ForeignKey(nameof(IngredientsId))]
        public virtual Ingredients Ingredients { get; set; }
    }
}