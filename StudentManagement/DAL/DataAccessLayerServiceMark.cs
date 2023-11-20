using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Model;

namespace StudentManagement.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public List<Marks> GetAllMarks() => ctx.MarksDb.ToList();
        public void AddMark(int grade, int studentId, int courseId)
        {
            if (!ctx.StudentsDb.Any(s => s.Id == studentId))
            {
                throw new Exception($"Id student invalid{studentId}");
            }

            if (!ctx.CoursesDb.Any(s => s.Id == courseId))
            {
                throw new Exception($"Id course invalid{courseId}");
            }

            ctx.MarksDb.Add(new Marks
            {
                Grade = grade,
                StudentId = studentId,
                CourseId = courseId,
                DataGrade = DateTime.Now
            });

            ctx.SaveChanges();
        }
    
        public List<Marks> GetAverage(int studentId, int courseId)
        {
            try
            {
                var student = ctx.StudentsDb.Include(s => s.Marks).FirstOrDefault(s => s.Id == studentId);

                if (student != null)
                {
                    var noteList = student.Marks.Where(n => n.CourseId == courseId).ToList();

                    if (noteList.Any())
                    {
                        var average = noteList.Average(n => n.Grade);
                        noteList.ForEach(n => n.AverageTotal = average);
                        return noteList;
                    }
                    else
                    {
                        return new List<Marks>();
                    }
                }
                else
                {
                    throw new Exception("Student doesn't exist!");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error trying get the average: {ex.Message}");
                throw;
            }
        }

    }
}
