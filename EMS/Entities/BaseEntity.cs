using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Entities
{
    public class BaseEntity
    {
        
        public int? CreatedBy { get; set; }   
        public DateTime? CreatedDate { get; set; }   
        public int? UpdatedBy { get; set; }   
        public DateTime? UpdatedDate { get; set; }   
        public int? DeletedBy { get; set; }   
        public DateTime? DeletedDate { get; set; }  
        public bool? Status { get; set; }    
    }
}
