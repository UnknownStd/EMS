using System.ComponentModel.DataAnnotations;
using EMS.Entities;

namespace EMS.Models
{
    public class SetUpDepertmentViewModel:BaseEntity
    {
		public int DepartmentId { get; set; }
        [Required] public string DepartmentName { get; set; } = string.Empty;
        public int ?DisplayNo { get; set; }
		public List<SetUpDepertmentViewModel> DepertmentList { get; set; }
		public SetUpDepertmentViewModel()
		{
			DepertmentList = new List<SetUpDepertmentViewModel>();
		}

		public static implicit operator List<object>(SetUpDepertmentViewModel? v)
		{
			throw new NotImplementedException();
		}
	}
}
