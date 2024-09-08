
using BusinessLayer.Business.Model.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Business.TeacherBusiness
{
    public interface ITeacherBusiness
    {
         TeacherModel GetDropDown(string UserName = "Admin");
        TeacherModel Insert(TeacherParam teacherParam);
    }
}
