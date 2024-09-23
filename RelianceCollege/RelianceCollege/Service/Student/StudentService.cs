using BusinessLayer.Business.Model.Student;
using RelianceCollege.Helper.DataContext;

namespace RelianceCollege.Service.Student
{
    public class StudentService: IStudentService
    {
        private readonly DataContext _dataContext;
        public StudentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<StudentResp> GetGridList(StudentModel studentModel)
        {
            try
            {
                var resp = _dataContext.Students.ToList();
                StudentResp studentResp = new StudentResp();
                studentResp.studentList = resp;
                return studentResp;

            }
            catch (Exception ex)
            {

                return new StudentResp
                {
                    Code = "101",
                    Message = ex.Message,

                };
            }
        }

        public async Task<StudentResp> Insert(StudentModel studentModel)
        {
            try
            {
                var resp = _dataContext.AddAsync(studentModel);
                        _dataContext.SaveChanges();
                return new StudentResp
                {
                    Code = "100",
                    Message = "Success",

                };
            }
            catch (Exception ex)
            {
                return new StudentResp
                {
                    Code="101",
                    Message=ex.Message,

                };
            }
        }
    }
}
