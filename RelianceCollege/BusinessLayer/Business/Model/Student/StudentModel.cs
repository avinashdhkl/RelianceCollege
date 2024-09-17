using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Business.Model.Student
{
    public class StudentResp: StudentModel
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
        public List<SelectListItem>? GenderList { get; set; }
        public List<SelectListItem>? SemesterList { get; set; }
        public List<StudentModel>? studentList { get; set; }
    }
    public class StudentModel
    {
        public int RowId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Semster { get; set; }
        public string Gender { get; set; }
    }
}
