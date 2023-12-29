using StudentManagement.Dto;
using StudentManagement.DTO;
using StudentManagement.Model;

namespace StudentManagement.Transform
{
    public static class StudentTransform
    {
        public static StudentGetDto ToDto(this Student student) =>
            student is null
            ? throw new Exception($"Student not Found {student}")
            : new StudentGetDto { Id = student.Id, Name = student.Name, Age = student.Age };

        public static GetTeacherDto ToDto(this Teachers teacher) =>
            teacher is null
            ? throw new Exception($"Teacher not found{teacher}")
            : new GetTeacherDto { Id = teacher.Id,Name = teacher.Name, Age = teacher.Age ,Description = teacher.Description};

        public static GetMarksDto ToDto(this Marks marks) =>
            marks is null
            ? throw new Exception("Cannot be null!!")
            : new GetMarksDto {  Id = marks.Id, Grade = marks.Grade, DataGrade = marks.DataGrade , CourseId = marks.CourseId ,StudentId = marks.StudentId}; 

        public static CourseGetDto ToDto(this Course course) =>
            course is null
            ? throw new Exception($"Course {course} data not found")
            : new CourseGetDto { Id = course.Id, Name = course.Name };

        public static Course ToEntity(this CreateCourseDto course) =>
            course is null
            ? throw new Exception($"Course alreadu exist! {course}")
            : new Course
            {
                Name = course.Name
            };

        public static Teachers ToEntity(this TeacherCreateDto teacher) =>
            teacher is null
            ? throw new Exception($"Teacher not created{teacher}")
            : new Teachers
            {
                Name = teacher.Name,
                Age = teacher.Age,
                Description = teacher.Description
            };

        public static Student ToEntity(this StudentCreateDto student) =>
            student is null
            ? throw new Exception($"Student data empty for {student}")
            : new Student
            {
                Name = student.Name,
                Age = student.Age,
            };

        public static Marks ToEntity(this MarkAddDto markss) =>
            markss is null
            ? throw new Exception("Cannot be nulll")
            : new Marks
            {
                StudentId = markss.StudentId,
                CourseId = markss.CourseId,
                Grade = markss.Grade,
                DataGrade = markss.DataGrade
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

        public static Course ToEntity(this CourseUpdateDto course) =>
            course is null 
            ? throw new Exception($"Course not found{course}")
            : new Course {Id = course.Id, Name = course.Name };

        public static StudentAddressDto ToDto(this Address studentAddress) =>
            studentAddress is null
            ? throw new Exception("Address not found !")
            : new StudentAddressDto { Id = studentAddress.Id ,Number = studentAddress.Number , City = studentAddress.City,Street = studentAddress.Street};
    }
}
