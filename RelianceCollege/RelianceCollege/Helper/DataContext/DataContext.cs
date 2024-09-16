using BusinessLayer.Business.Model.Student;
using Microsoft.EntityFrameworkCore;

namespace RelianceCollege.Helper.DataContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<StudentModel> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentModel>().HasKey(x=>x.RowId);
            modelBuilder.Entity<StudentModel>(x => x.ToTable("Tbl_Student", "Student"));
        }
    }
  
}
