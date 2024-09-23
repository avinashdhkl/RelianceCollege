using BusinessLayer.Business.Model.Student;
using BusinessLayer.Business.TeacherBusiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RelianceCollege.Service.Student;

namespace RelianceCollege.Controllers
{
    public class StudentController : Controller
    {
        private readonly ITeacherBusiness _teacherBusiness;
        private readonly IStudentService _studentService;
        public StudentController(ITeacherBusiness teacherBusiness, IStudentService studentService)
        {
            _studentService = studentService;
            _teacherBusiness = teacherBusiness;
        }
        public IActionResult Index()
        {
            StudentModel studentModel= new StudentModel();
            var resp = _studentService.GetGridList(studentModel).Result;
            return View(resp);
        }
        [HttpGet]
        public IActionResult Manage()
        {
            StudentResp studentResp = new StudentResp();
            var dropDownResp = _teacherBusiness.GetDropDown();
            studentResp.GenderList = dropDownResp.ListGender.Select(x => new SelectListItem { Value = x.Value, Text = x.Text }).ToList();
            studentResp.SemesterList = dropDownResp.ListSemester.Select(x => new SelectListItem { Value = x.Value, Text = x.Text }).ToList();
            return View(studentResp);
        }
        [HttpPost]
        public IActionResult Manage(StudentResp studentResp)
        {
            var studentmodel = new StudentModel
            {
                FullName = studentResp.FullName,
                Address = studentResp.Address,
                PhoneNo = studentResp.PhoneNo,
                Email = studentResp.Email,
                Semster = studentResp.Semster,
                Gender = studentResp.Gender,
            };
            var resp = _studentService.Insert(studentmodel).Result;
           return RedirectToAction("Index");
        }
    }
}
