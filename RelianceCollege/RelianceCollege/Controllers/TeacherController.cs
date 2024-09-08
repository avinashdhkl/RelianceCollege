using BusinessLayer.Business.Model.Teacher;
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
        [HttpGet]
        public IActionResult Manage()
        {
            //TeacherModel model = new TeacherModel();
            var dropdownList = _teacherBusiness.GetDropDown();
            //dropdownList.ListGender = dropdownList.ListGender.Where(x=>x.Value=="M")
            dropdownList.GenderList = dropdownList.ListGender.Select(x => new SelectListItem { Value = x.Value, Text = x.Text }).ToList();
            dropdownList.SemesterList = dropdownList.ListSemester.Select(x => new SelectListItem { Value= x.Value, Text = x.Text }).ToList();
            return View(dropdownList);
        }
        [HttpPost]
        public IActionResult Manage(TeacherModel teacherModel)
        {
            var param = new TeacherParam()
            {
                
                FullName = teacherModel.FullName,
                Address = teacherModel.Address,
                Email = teacherModel.Email,
                Mobileno = teacherModel.Mobileno,
                Gender = teacherModel.Gender,
                Sem = teacherModel.Sem,
            };
            var resp = _teacherBusiness.Insert(param);
            return RedirectToAction("Index", "Home");
        }
    }
}
