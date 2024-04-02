using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Entities
{
    public class EmployeeInfo:BaseEntity
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
		public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phoneno { get; set; } = string.Empty;
        public int? Gender { get; set; }
        public string Address { get; set; } = string.Empty;

        public string ProfileImagePath { get; set; } = string.Empty;


    }
}
