using BusinessLayer.Business.Model.Teacher;
using DatabaseLayer.Drapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Business.TeacherBusiness
{
    public class TeacherBusiness:ITeacherBusiness
    {
        private readonly IDrapper _drapper;
        public TeacherBusiness(IDrapper drapper)
        {
            _drapper = drapper;
        }
        public TeacherModel GetDropDown(string UserName = "Admin")
        {
            try
            {
                var Flag = "DropDown";
                var param = new
                {
                    Flag = Flag,
                };
                TeacherModel teacherModel = new TeacherModel();
                var resp = _drapper.DatawithMultiple<SelectListModel, SelectListModel>("Teacher.Proc_TeacherDetails", param);
                teacherModel.ListGender = (List<SelectListModel>)resp[0];
                teacherModel.ListSemester = (List<SelectListModel>)resp[1];
                return teacherModel;


            }
            catch (Exception ex)
            {

                return new TeacherModel
                {
                    Code="101",
                    Message=ex.Message,

                };
            }
        }

        public TeacherModel Insert(TeacherParam teacherParam)
        {
            try
            {
                var Flag = "insert";
                var param = new
                {
                    Flag = Flag,
                    FullName = teacherParam.FullName,
                    Address = teacherParam.Address,
                    Email = teacherParam.Email,
                    Mobileno = teacherParam.Mobileno,
                    Gender = teacherParam.Gender,
                    Sem = teacherParam.Sem,
                };               
                var resp = _drapper.DatawithSingleObject<TeacherModel>("Teacher.Proc_TeacherDetails", param);               
                return resp;


            }
            catch (Exception ex)
            {

                return new TeacherModel
                {
                    Code = "101",
                    Message = ex.Message,

                };
            }
        }
    }
}
