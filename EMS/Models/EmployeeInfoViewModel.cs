using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class EmployeeInfoViewModel
    {
		public int EmployeeId { get; set; }
		public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phoneno { get; set; } = string.Empty;
        public int ?Gender { get; set; } 
        public string Address { get; set; } = string.Empty;
        public string ProfileImagePath { get; set; } = string.Empty;
        public List<EmployeeInfoViewModel> EmployeeList { get; set; }
        public EmployeeInfoViewModel() 
        { 
            EmployeeList = new List<EmployeeInfoViewModel>();
        }
    }
    
}
