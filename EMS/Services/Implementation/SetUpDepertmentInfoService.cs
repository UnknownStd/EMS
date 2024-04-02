using EMS.ConnectionString;
using EMS.Entities;
using EMS.Models;
using EMS.Services.Interface;

namespace EMS.Services.Implementation
{
    public class SetUpDepertmentInfoService:ISetUpDepertmentInfoService
    {
        private readonly DBConnection _connection;

        public SetUpDepertmentInfoService(DBConnection connection) 
        {
            _connection = connection;   
        }
        public int GetDepertmentById(int DepertmentId) { return 1; }
        public void SaveDepertment(SetUpDepertmentViewModel model) 
        {
            SetUpDepertment department = new SetUpDepertment();
            department.DepartmentName = model.DepartmentName;
            department.DisplayNo = model.DisplayNo;
            department.CreatedBy = 1;
            department.CreatedDate = DateTime.Now;
            _connection.Add(department);
            _connection.SaveChanges();
        }
        public void DeleteDepertment(int DepertmentId) 
        {
			var department = _connection.SetUpDepertment.FirstOrDefault(x => x.DepartmentId == DepertmentId);
            if (department != null)
            {
                department.DeletedBy = 1;
                department.DeletedDate = DateTime.Now;
            }
			_connection.SaveChanges();
;
		}


        public List<SetUpDepertmentViewModel> GetDepertmentList()
        {
            var data = _connection.SetUpDepertment.ToList(); 
			var departmentlist = new List<SetUpDepertmentViewModel>();
			if (data.Count > 0)
			{
				foreach (var item in data)
				{
					departmentlist.Add(new SetUpDepertmentViewModel()
					{
                        DepartmentId = item.DepartmentId,
						DepartmentName = item.DepartmentName,
                        DisplayNo = item.DisplayNo,
                        DeletedBy = item.DeletedBy,
					});
				}
			}
			return departmentlist;
			/*SetUpDepertmentViewModel departmnetModel1 = new SetUpDepertmentViewModel();
            departmnetModel1.DisplayNo = 12;
            departmnetModel1.DepartmentName = "Markting";
            departmentlist.Add(departmnetModel1);
			SetUpDepertmentViewModel departmnetModel2 = new SetUpDepertmentViewModel();
			departmnetModel2.DisplayNo = 13;
			departmnetModel2.DepartmentName = "Learning";
			departmentlist.Add(departmnetModel2);

            return departmentlist;*/
		}
		public bool UpdateDepertment(int depertmentId, SetUpDepertmentViewModel model)
		{
            var department = _connection.SetUpDepertment.FirstOrDefault(x => x.DepartmentId == depertmentId);
            if (department  != null)
            {
                department.DepartmentName = model.DepartmentName;
                department.DisplayNo = model.DisplayNo;
                department.UpdatedBy = 1;
                department.UpdatedDate = DateTime.Now;
            }
			_connection.SaveChanges();

			return true;
		}
	}
    
}
