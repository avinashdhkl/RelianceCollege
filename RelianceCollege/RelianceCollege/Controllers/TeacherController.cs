using BusinessLayer.Business.Model.Teacher;
using BusinessLayer.Business.TeacherBusiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;


namespace RelianceCollege.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherBusiness _teacherBusiness;
        public TeacherController(ITeacherBusiness teacherBusiness)
        {
            _teacherBusiness = teacherBusiness;
        }

        [HttpGet]
        public IActionResult Index(TeacherParam teacherParam)
        {
            var resp = _teacherBusiness.GridList(teacherParam);
            return View(resp);
        }
        [HttpGet]
        public IActionResult Manage(string id)
        {
            var dropdownList = _teacherBusiness.GetDropDown();
            //dropdownList.ListGender = dropdownList.ListGender.Where(x=>x.Value=="M")
            dropdownList.GenderList = dropdownList.ListGender.Select(x => new SelectListItem { Value = x.Value, Text = x.Text }).ToList();
            dropdownList.SemesterList = dropdownList.ListSemester.Select(x => new SelectListItem { Value = x.Value, Text = x.Text }).ToList();
            if (!string.IsNullOrEmpty(id))
            {
                TeacherParam teacherParam = new TeacherParam();
                teacherParam.RowId = id;
                var resp = _teacherBusiness.GetDetailsById(teacherParam);
                resp.GenderList = dropdownList.GenderList;
                resp.SemesterList = dropdownList.SemesterList;
                return View(resp);
            }

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
                RowId = teacherModel.RowId,
            };
            if (!string.IsNullOrEmpty(teacherModel.RowId))
            {
                var res = _teacherBusiness.Update(param);
            }
            else
            {
                var resp = _teacherBusiness.Insert(param);
            }
            
            return RedirectToAction("Index");
        }
    }
}
