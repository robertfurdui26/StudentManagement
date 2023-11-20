using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Model;

namespace StudentManagement.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {     
        public List<Course> GetCourses() => ctx.CoursesDb.ToList();

        public Course AddCourse(string nameCourse)
        {
            var course = new Course { Name = nameCourse };
            ctx.CoursesDb.Add(course);
            ctx.SaveChanges();
            return course;
        }
    }
}
