using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Business.Model.Teacher
{
    public class TeacherModel : TeacherParam
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
        public List<SelectListItem>? GenderList { get; set; }
        public List<SelectListItem>? SemesterList { get; set; }
        public List<SelectListModel>? ListGender { get; set; }
        public List<SelectListModel>? ListSemester { get; set; }
    }
    public class TeacherParam
    {
        public string? RowId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Mobileno { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Sem { get; set; }
        public string? Flag { get; set; }
    }
    public class SelectListModel
    {
        public string? Text { get; set; }
        public string? Value { get; set; }
    }
}
