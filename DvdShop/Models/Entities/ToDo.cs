using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DvdShop.Models.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int StudioId { get; set; }
        [ForeignKey(nameof(StudioId))]
        public virtual Studio Studio { get; set; }
    }
}