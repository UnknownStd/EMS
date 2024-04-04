using EMS.Models;
using Microsoft.AspNetCore.Mvc;
using EMS.Services.Interface;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using EMS.Services.Implementation;

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
		public IActionResult Displayemployess()
		{
			EmployeeInfoViewModel employeeInfoViewModel = new EmployeeInfoViewModel();
			var employeelist = _iEmployeeInfoService.GetEmployeeList();
			employeeInfoViewModel.EmployeeList = employeelist.Where(x => x.DeletedBy == null).ToList();
			return View(employeeInfoViewModel);
		}
		[HttpGet]
        public IActionResult Displaydata(int employeeid) 
        {
			EmployeeInfoViewModel employeeInfoViewModel = new EmployeeInfoViewModel();
			var data = _iEmployeeInfoService.GetEmployeeById(employeeid);
            return View(data);
		}
        /*post method*/
        [HttpPost]
        public IActionResult Create(EmployeeInfoViewModel employee)
        {
            var result = _iEmployeeInfoService;
            result.SaveEmployee(employee);
			return RedirectToAction("Displayemployess");
		}
        [HttpGet]
		public IActionResult Details(int EmployeeId)
		{
			EmployeeInfoViewModel model = new EmployeeInfoViewModel();
			var data = _iEmployeeInfoService.GetEmployeeList();
			model = data.Where(x => x.EmployeeId == EmployeeId).FirstOrDefault();
			return View(model);
		}
        [HttpPost]
		public IActionResult Details(EmployeeInfoViewModel employee)
		{
			if (ModelState.IsValid)
			{
				_iEmployeeInfoService.UpdateEmployee(employee.EmployeeId, employee);
			}
			return RedirectToAction("Displayemployess");
		}
		[HttpGet]
		public IActionResult Delete(int employeeId)
		{
		    EmployeeInfoViewModel model = new EmployeeInfoViewModel();
			var data = _iEmployeeInfoService.GetEmployeeList();
			model = data.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
			return View(model);
		}
		[HttpPost]
		public IActionResult Delete(EmployeeInfoViewModel employee)
		{
			int employeeid = employee.EmployeeId;
			_iEmployeeInfoService.DeleteEmployee(employeeid);
			return RedirectToAction("Displayemployess");
		}
	}
}
