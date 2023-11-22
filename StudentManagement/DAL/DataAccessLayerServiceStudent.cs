using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Model;

namespace StudentManagement.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        private readonly StudentDbContext ctx;

        public DataAccessLayerService(StudentDbContext ctx)
        {
            this.ctx = ctx;
        }
       
        public IEnumerable<Student> GetStudents() => ctx.StudentsDb.ToList();
        public Address StudentAddress(int studentId)
        {
            var student = ctx.StudentsDb.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);
            if (student is not null)
            {
                return student.Address;
            }
            throw new Exception($"Student id not found for student {studentId}");
        }

        public Student StudentById(int id) => ctx.StudentsDb.FirstOrDefault(s => s.Id == id);

        public Student AddStudent(Student student)
        {
            if (ctx.StudentsDb.Any(s => s.Id == student.Id))
            {
                throw new Exception($"Student already exist!!!{student}");
            }
            ctx.StudentsDb.Add(student);
            ctx.SaveChanges();
            return student;
        }

        public Student Update(Student studentToUpdate)
        {
            var student = ctx.StudentsDb.FirstOrDefault(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                throw new Exception($"Student not found{student}");
            }
            student.Name = studentToUpdate.Name;
            student.Age = studentToUpdate.Age;
            ctx.SaveChanges();
            return student;

        }

        public IEnumerable<Student> GetStudentByAverageOrder()
        {
            try
            {
                var students = ctx.StudentsDb.ToList();
                var studentAverageList = students
            .OrderByDescending(s => s.CalculateTotalAverage()).Select(s => new Student
            {
                Id = s.Id,
                Name = s.Name,
                Age = s.Age,
                StudentTotalAverage = s.CalculateTotalAverage()
            }).ToList();

                return studentAverageList;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error trying get student: {ex.Message}");
                throw;
            }
        }
        public void DeleteStudent(int studentId)
        {
            var student = ctx.StudentsDb.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new Exception($"Student doesn't exist {studentId}");
            }
            ctx.StudentsDb.Remove(student);
            ctx.SaveChanges();

        }

      

    }
}
