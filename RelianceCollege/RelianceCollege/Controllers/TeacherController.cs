using BusinessLayer.Business.TeacherBusiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RelianceCollege.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherBusiness _teacherBusiness;
        public TeacherController(ITeacherBusiness teacherBusiness)
        {
            _teacherBusiness = teacherBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Manage()
        {
            //TeacherModel model = new TeacherModel();
            var dropdownList = _teacherBusiness.GetDropDown();
            dropdownList.GenderList = dropdownList.ListGender.Select(x=>new SelectListItem {Value=x.Value,Text=x.Text}).ToList();
            return View(dropdownList);
        }
    }
}
