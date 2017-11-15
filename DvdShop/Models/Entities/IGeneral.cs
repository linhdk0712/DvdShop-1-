using System;

namespace DvdShop.Models.Entities
{
    public interface IGeneral
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
        bool Status { get; set; }
    }
}
