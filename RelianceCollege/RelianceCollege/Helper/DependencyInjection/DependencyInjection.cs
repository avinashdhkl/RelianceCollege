using BusinessLayer.Business.StudentBusiness;
using BusinessLayer.Business.TeacherBusiness;
using DatabaseLayer.Drapper;
using DatabaseLayer.Execute;

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
            services.AddSingleton<IStudentBusiness, StudentBusiness>();
            services.AddSingleton<ITeacherBusiness, TeacherBusiness>();
            #endregion Business Layer
            return services;
         
        }
    }
}
