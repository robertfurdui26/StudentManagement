using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Model;

namespace StudentManagement.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public async Task<IEnumerable<Course>> GetAll()
        {
          return await ctx.CoursesDb.ToListAsync();
        }

        public async Task<Course> AddCourse(Course course)
        {
            if(ctx.CoursesDb.Any(s => s.Id == course.Id))
            {
                throw new Exception($"Course already exist ! {course}");
            }

            ctx.Add(course);
            await ctx.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpCourse(Course courseUpdate)
        {
            var course = await ctx.CoursesDb.FirstOrDefaultAsync(s => s.Id == courseUpdate.Id);
            if (course == null)
            {
                throw new Exception($"Course not found{course}");
            }
            course.Name = courseUpdate.Name;
            ctx.SaveChanges();
            return course;
        }
      


    }
}
