using EasySchoolManager.Model.Domain.Academic;
using EasySchoolManager.Model.Domain.People.Base;
using EasySchoolManager.Model.Domain.People.Staff;
using EasySchoolManager.Model.Domain.People.Students;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolManager.Infra
{
    public class DataBaseContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Customers { get; set; }

        public DbSet<Director> Directors { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherGrade> TeacherGrades { get; set; }

        public DbSet<Subject> Matters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }

        public DbSet<Secretary> Secretaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
        }
    }
}
