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

        public async Task<IEnumerable<Student>> GetAllStudents() 
        { 
            return await ctx.StudentsDb.OrderBy(c => c.Id).ToListAsync();
        } 

        public async Task<Student> GetIdStudent(int studentId)
        {
            var student = await ctx.StudentsDb.FirstOrDefaultAsync(s => s.Id == studentId);
            if(student == null)
            {
                throw new Exception($"Student with id {studentId} doesn't exist ");
            }
            return student;
        }

        public async Task<Student> AddStudent(Student student)
        {
            if ( ctx.StudentsDb.Any(s => s.Id == student.Id))
            {
                throw new Exception($"Student already exist!!!{student}");
            }
            ctx.StudentsDb.Add(student);
             await ctx.SaveChangesAsync();
            return student;
        }

        public async Task<User> AddUser(User user)
        {
            if( ctx.UserDb.Any(s =>s.UserName == user.UserName))
            {
                throw new Exception($"Student with name {user.UserName} exist already!");
            }
            ctx.UserDb.Add(user);
            await ctx.SaveChangesAsync();
            return user;
        }

        public  async Task<Address> StudentAddress(int studentId)
        {
            var student = await ctx.StudentsDb.Include(s => s.Address).FirstOrDefaultAsync(s => s.Id == studentId);
            if (student is not null)
            {
                return student.Address;
            }
            throw new Exception($"Student id not found for student {studentId}");
        }

        public async Task<Student> Update(Student studentToUpdate)
        {
            var student = await ctx.StudentsDb.FirstOrDefaultAsync(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                throw new Exception($"Student not found{student}");
            }
            student.Name = studentToUpdate.Name;
            student.Age = studentToUpdate.Age;
            ctx.SaveChanges();
            return student;

        }

        public async Task DeleteStudent(int studentId)
        {
            var student = await ctx.StudentsDb.FirstOrDefaultAsync(s => s.Id == studentId);
            if (student == null)
            {
                throw new Exception($"Student  {studentId} doesn't exist!");
            }
            ctx.StudentsDb.Remove(student);
           await ctx.SaveChangesAsync();

        } 
    }
}
