using Microsoft.EntityFrameworkCore;
using StudentManagement.Model;

namespace StudentManagement.Data
{
    public class StudentDbContect : DbContext
    {
        public StudentDbContect(DbContextOptions<StudentDbContect> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student > StudentsDb { get; set; }
        public DbSet<Address> AddressDb { get; set; }
    }
}
