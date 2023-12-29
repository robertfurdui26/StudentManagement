using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Dto;
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

            ctx.AddAsync(course);
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

     
        public async Task DeleteCourse(int courseId)
        {
            var course = await ctx.CoursesDb.FirstOrDefaultAsync(s => s.Id == courseId);

            if (course == null)
            {
                throw new Exception($"Course with id {courseId} does not exist!");
            }

            ctx.CoursesDb.Remove(course);
            await ctx.SaveChangesAsync();
        }

    }
}
