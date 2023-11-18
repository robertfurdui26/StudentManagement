using StudentManagement.Data;
using StudentManagement.Model;

namespace StudentManagement.DAL
{
    public class DataAccessLayerService
    {
        private readonly StudentDbContect ctx;

        public DataAccessLayerService(StudentDbContect ctx)
        {
            this.ctx = ctx;
        }
        #region Seed
        public void Seed()
        {
            ctx.Add(new Student
            {
                Name = "Robert",
                Age = 54,
                Address = new Address
                {
                    Number = 43,
                    Street = "Alea Parc",
                    City = "Oradea"
                }
            });

            ctx.Add(new Student
            {
                Name = "Marian",
                Age = 34,
                Address = new Address
                {
                    Number = 88,
                    Street = "Gheorghiu Dej",
                    City = "Sebes"
                }
            });

            ctx.Add(new Student
            {
                Name = "Octavian",
                Age = 23,
                Address = new Address
                {
                    Number = 12,
                    Street = "Maniu ",
                    City = "Mures"
                }
            });

            ctx.SaveChanges();
        }
        #endregion

        public IEnumerable<Student> GetStudents() => ctx.StudentsDb.ToList();

        public Student AddStudent( Student student)
        {
            if(ctx.StudentsDb.Any( s => s.Id == student.Id))
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

        public void DeleteStudent(int studentId)
        {
            var student = ctx.StudentsDb.FirstOrDefault(s =>s.Id == studentId);
            if(student == null)
            {
                throw new Exception($"Student doesn't exist {studentId}");
            }
            ctx.StudentsDb.Remove(student);
            ctx.SaveChanges();
            
        }

    }
}
