using Microsoft.EntityFrameworkCore;
using StudentManagement.Model;

namespace StudentManagement.Data
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> StudentsDb { get; set; }
        public DbSet<Address> AddressDb { get; set; }
        public DbSet<Marks> MarksDb { get; set; }
        public DbSet<Course> CoursesDb { get; set; }
        public DbSet<Teachers> TeachersDb { get; set; }
    }
}
