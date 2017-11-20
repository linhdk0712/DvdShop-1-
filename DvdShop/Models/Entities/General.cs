using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DvdShop.Models.Entities
{
    public class General: IGeneral
    {
        protected General()
        {
           
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public DateTime CreatedDate { get; set; }
       
        public string CreatedBy { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
       
        public string UpdatedBy { get; set; }
       
        public bool Status { get; set; }
    }
}