using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Model;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StudentManagement.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {

        public async Task<IEnumerable<Marks>> GetStudentMark()
        {
            return await ctx.MarksDb.ToListAsync();
        }

        public async Task<Marks> AddMark(int studentId, int courseId, int grade)
        {
            if (!ctx.StudentsDb.Any(s => s.Id == studentId))
            {
                throw new Exception($"Id invalid for student {studentId}");
            }

            if (!ctx.CoursesDb.Any(c => c.Id == courseId))
            {
                throw new Exception($"Id invalid for course {courseId}");
            }

            var newMark = new Marks
            {
                StudentId = studentId,
                CourseId = courseId,
                Grade = grade,
                DataGrade = DateTime.Now
                
            };

            ctx.MarksDb.Add(newMark);
            await ctx.SaveChangesAsync();

            return newMark;
        }






    }
}
