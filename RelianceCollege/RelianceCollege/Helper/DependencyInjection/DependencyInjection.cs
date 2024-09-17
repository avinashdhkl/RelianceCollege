
using BusinessLayer.Business.TeacherBusiness;
using DatabaseLayer.Drapper;
using DatabaseLayer.Execute;
using RelianceCollege.Service.Student;

namespace RelianceCollege.Helper.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegistionationService(this IServiceCollection services)
        {
            #region Data Layyer
            services.AddSingleton<IExecute, Execute>();
            services.AddSingleton<IDrapper, Drapper>();
            #endregion Data layer
            #region Business Layer
            //services.AddSingleton<IStudentBusiness, StudentBusiness>();
            services.AddSingleton<ITeacherBusiness, TeacherBusiness>();
            #endregion Business Layer
            #region Entity
            services.AddScoped<IStudentService, StudentService>();
            #endregion Entity
            return services;
         
        }
    }
}
