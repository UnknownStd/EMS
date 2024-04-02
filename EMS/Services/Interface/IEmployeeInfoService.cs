using EMS.Models;

namespace EMS.Services.Interface
{
    public interface IEmployeeInfoService
    {
        public int GetEmployeeById(int employeeId);
        public void SaveEmployee(EmployeeInfoViewModel employee);
        public void DeleteEmployee(int employeeId);
        List<EmployeeInfoViewModel> GetEmployeeList();
    }
}
