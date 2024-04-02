using EMS.Models;
using EMS.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    public class SetUpDepertmentController : Controller
    {
        public readonly ISetUpDepertmentInfoService _iSetUpDepertmentInfoService; //object created
        public SetUpDepertmentController(ISetUpDepertmentInfoService iSetUpDepertmentInfoService) //constructor created
        {
            this._iSetUpDepertmentInfoService = iSetUpDepertmentInfoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DepartmentInfo()
        {
            SetUpDepertmentViewModel setUpDepertmentViewModel = new SetUpDepertmentViewModel();
           /* setUpDepertmentViewModel.DepertmentList = _iSetUpDepertmentInfoService.GetDepertmentList();*/
            var departmentlist = _iSetUpDepertmentInfoService.GetDepertmentList();
            setUpDepertmentViewModel.DepertmentList = departmentlist.Where(x => x.DeletedBy == null).ToList(); 
            /*var data = setUpDepertmentViewModel.DepertmentList.Where(x => x.DeletedBy != null).FirstOrDefault();*/
            return View(setUpDepertmentViewModel);
        }
        [HttpPost]
        public IActionResult Create(SetUpDepertmentViewModel Depart)
        {
            var result = _iSetUpDepertmentInfoService;
            result.SaveDepertment(Depart);
            return RedirectToAction("DepartmentInfo");
        }
        [HttpGet]
        public IActionResult Details(int DepartmentId)
        {
            SetUpDepertmentViewModel model = new SetUpDepertmentViewModel();
            var data = _iSetUpDepertmentInfoService.GetDepertmentList();
            model = data.Where(x => x.DepartmentId == DepartmentId).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
		public IActionResult Details(SetUpDepertmentViewModel Depart)
        {
            if(ModelState.IsValid) 
            {
                _iSetUpDepertmentInfoService.UpdateDepertment(Depart.DepartmentId, Depart);
            }
            return RedirectToAction("DepartmentInfo");
		}
		[HttpGet]
		public IActionResult Delete(int DepartmentId)
		{
			SetUpDepertmentViewModel model = new SetUpDepertmentViewModel();
			var data = _iSetUpDepertmentInfoService.GetDepertmentList();
			model = data.Where(x => x.DepartmentId == DepartmentId).FirstOrDefault();
			return View(model);
		}
		[HttpPost]
		public IActionResult Delete(SetUpDepertmentViewModel Depart)
		{
            int departid = Depart.DepartmentId;
            _iSetUpDepertmentInfoService.DeleteDepertment(departid);
			return RedirectToAction("DepartmentInfo");
		}

	}
}