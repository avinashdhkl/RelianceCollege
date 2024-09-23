using BusinessLayer.Business.Model.Student;

namespace RelianceCollege.Service.Student
{
    public interface IStudentService
    {
        Task<StudentResp> Insert(StudentModel studentModel);
        Task<StudentResp> GetGridList(StudentModel studentModel);
    }
}
