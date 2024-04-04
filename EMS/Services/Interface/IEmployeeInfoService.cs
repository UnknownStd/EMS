using EMS.Models;

namespace EMS.Services.Interface
{
    public interface IEmployeeInfoService
    {
        public EmployeeInfoViewModel GetEmployeeById(int employeeId);
        public void SaveEmployee(EmployeeInfoViewModel employee);
        public void DeleteEmployee(int employeeId);
        List<EmployeeInfoViewModel> GetEmployeeList();
		public bool UpdateEmployee(int employeeId, EmployeeInfoViewModel employee);
	}
}
