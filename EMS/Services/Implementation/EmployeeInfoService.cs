 using System.Security.Cryptography.X509Certificates;
using EMS.Models;
using EMS.Entities;
using EMS.Services.Interface;
using EMS.ConnectionString;

namespace EMS.Services.Implementation
{
	public class EmployeeInfoService:IEmployeeInfoService
    {
		private readonly DBConnection _connection;
		public EmployeeInfoService(DBConnection connection) 
        {
            _connection = connection;
        }
        public EmployeeInfoViewModel GetEmployeeById(int employeeId) 
        {
            var data = _connection.EmployeeInfo.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
            EmployeeInfoViewModel model = new EmployeeInfoViewModel();
            if(data != null) 
            {
                model.EmployeeId = data.EmployeeId;
			    model.FirstName = data.FirstName;
			    model.LastName = data.LastName;
			    model.Email = data.Email;
			    model.Phoneno = data.Phoneno;
			    model.Gender = data.Gender;
			    model.Address = data.Address;
			    model.ProfileImagePath = data.ProfileImagePath;
            }
			return model; 
        }
        public void SaveEmployee(EmployeeInfoViewModel employee) 
        {
            EmployeeInfo employeeinfo = new EmployeeInfo();
            employeeinfo.FirstName = employee.FirstName;
            employeeinfo.LastName = employee.LastName;
            employeeinfo.Email = employee.Email;
            employeeinfo.Phoneno = employee.Phoneno;
            employeeinfo.Gender = employee.Gender;
            employeeinfo.Address = employee.Address;
            employeeinfo.ProfileImagePath = employee.ProfileImagePath;
            employeeinfo.CreatedBy = 1;
            employeeinfo.CreatedDate = DateTime.Now;
			_connection.Add(employeeinfo);
			_connection.SaveChanges();
		}
        public void DeleteEmployee(int employeeId)
        {
			var employee = _connection.EmployeeInfo.FirstOrDefault(x => x.EmployeeId == employeeId);
			if (employee != null)
			{
				employee.DeletedBy = 1;
				employee.DeletedDate = DateTime.Now;
			}
            _connection.Update(employee);
			_connection.SaveChanges();
		}

        public List<EmployeeInfoViewModel> GetEmployeeList()
        {
            var data = _connection.EmployeeInfo.ToList();
            var employeelist = new List<EmployeeInfoViewModel>();
			if (data.Count > 0)
			{
				foreach (var item in data)
				{
				    employeelist.Add(new EmployeeInfoViewModel()
					{
						FirstName = item.FirstName,
                        LastName = item.LastName,
						Address = item.Address,
						Email = item.Email,
						Gender = item.Gender,
						Phoneno = item.Phoneno,
                        ProfileImagePath = item.ProfileImagePath,
                        EmployeeId = item.EmployeeId,
                        DeletedBy = item.DeletedBy,
					});
				}
			}
			return employeelist;
			/*EmployeeInfoViewModel employeeInfoViewModel1 = new EmployeeInfoViewModel();*/
            /*employeeInfoViewModel1.FirstName = "Aashish";
            employeeInfoViewModel1.LastName = "Tamang";
            employeeInfoViewModel1.Address = "Sinamangal";
            employeeInfoViewModel1.Email = "aashishtamang@gmail.com";
            employeeInfoViewModel1.Gender = 1;
            employeeInfoViewModel1.Phoneno = "9767644123";
            employeelist.Add(employeeInfoViewModel1);

            EmployeeInfoViewModel employeeInfoViewModel = new EmployeeInfoViewModel();
            employeeInfoViewModel.FirstName = "Arjun";
            employeeInfoViewModel.LastName = "Tamang";
            employeeInfoViewModel.Address = "Kathmandu";
            employeeInfoViewModel.Email = "tamang123@gmail.com";
            employeeInfoViewModel.Gender = 1;
            employeeInfoViewModel.Phoneno = "9213154676";
            employeelist.Add(employeeInfoViewModel);

            EmployeeInfoViewModel employeeInfoViewModel2 = new EmployeeInfoViewModel();
            employeeInfoViewModel2.FirstName = "Sunita";
            employeeInfoViewModel2.LastName = "Ghising";
            employeeInfoViewModel2.Address = "Kathmandu";
            employeeInfoViewModel2.Email = "Ghisingsunita@gmail.com";
            employeeInfoViewModel2.Gender = 2;
            employeeInfoViewModel2.Phoneno = "9276754676";
            employeelist.Add(employeeInfoViewModel2);

            return employeelist;*/
        }
		public bool UpdateEmployee(int employeeId, EmployeeInfoViewModel employee)
        {
			var employeedata = _connection.EmployeeInfo.FirstOrDefault(x => x.EmployeeId == employeeId);
			if (employeedata != null)
			{
				employeedata.FirstName = employee.FirstName;
                employeedata.LastName = employee.LastName;
				employeedata.Phoneno = employee.Phoneno;
                employeedata.Email = employee.Email;
                employeedata.Address = employee.Address;
                employeedata.Gender = employee.Gender;
                employeedata.ProfileImagePath = employee.ProfileImagePath;
				employeedata.UpdatedBy = 1;
				employeedata.UpdatedDate = DateTime.Now;
			}
            _connection.Update(employeedata);
			_connection.SaveChanges();
			return true;
        }
	}
}
