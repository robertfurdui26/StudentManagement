using StudentManagement.DTO;
using StudentManagement.Model;
using System.Reflection.Metadata.Ecma335;

namespace StudentManagement.Transform
{
    public static class StudentTransform
    {
        public static StudentGetDto ToDto(this Student student) =>
            student is null
            ? throw new Exception($"Student cannot created{student}")
            : new StudentGetDto { Id =  student.Id ,Name = student.Name , Age = student.Age};

        public static Student ToEntity(this StudentCreateDto student) =>
            student is null
            ? throw new Exception($"Student data empty for {student}")
            : new Student
            {
                Name = student.Name,
                Age = student.Age,
            };
        public static Student ToEntity(this StudentUpdateDto student) =>
            student is null
            ? throw new Exception($"Student not found{student}!!")
            : new Student
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
            };
        
    }
}
