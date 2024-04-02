using EMS.Models;
using Microsoft.AspNetCore.Mvc;
using EMS.Services.Interface;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EMS.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly IEmployeeInfoService _iEmployeeInfoService; //object created
        public EmployeeController(IEmployeeInfoService iEmployeeInfoService) //constructor created
        {
            this._iEmployeeInfoService = iEmployeeInfoService;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        /*get method*/
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Displaydata() 
        {
			EmployeeInfoViewModel employeeInfoViewModel = new EmployeeInfoViewModel();
            employeeInfoViewModel.EmployeeList = _iEmployeeInfoService.GetEmployeeList();
            return View(employeeInfoViewModel);
		}
        /*post method*/
        [HttpPost]
        public IActionResult Create(EmployeeInfoViewModel employee)
        {
            var result = _iEmployeeInfoService;
            result.SaveEmployee(employee);
            return View();
        }
		/*public IActionResult Read()
        {
            string connectionstring = configuration.GetConnectionString("DefaultConnectionString");

            SqlConnection connection = new SqlConnection(connectionstring);
            return View();
        }*/
		public IActionResult Details(int EmployeeId)
		{
            var data = _iEmployeeInfoService.GetEmployeeList();
            EmployeeInfoViewModel model = new EmployeeInfoViewModel();
			/*model = data.Where(x => x.Phoneno == Phoneno).FirstOrDefault();*/
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
			model = (from e in data
					 where e.EmployeeId == EmployeeId
					 select new EmployeeInfoViewModel
                            {
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Address = e.Address,
                                Gender = e.Gender,
                                Email = e.Email,
                                Phoneno = e.Phoneno,
                                ProfileImagePath = e.ProfileImagePath,
                            } ).FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
			/*model = (from e in data where e.Phoneno == Phoneno select new {e.FirstName,e.LastName}).FirstOrDefault();*/
			return View(model);
		}
	}
}
