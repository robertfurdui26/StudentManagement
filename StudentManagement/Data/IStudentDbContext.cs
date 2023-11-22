using Microsoft.EntityFrameworkCore;
using StudentManagement.Model;

namespace StudentManagement.Data
{
    public interface IStudentDbContext
    {
        DbSet<Address> AddressDb { get; set; }
        DbSet<Course> CoursesDb { get; set; }
        DbSet<Marks> MarksDb { get; set; }
        DbSet<Student> StudentsDb { get; set; }
        DbSet<Teachers> TeachersDb { get; set; }
    }
}