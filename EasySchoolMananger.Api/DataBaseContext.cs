using EasySchoolMananger.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolMananger.Api
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
