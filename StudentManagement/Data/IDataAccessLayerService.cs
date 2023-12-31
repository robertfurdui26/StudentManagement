﻿using StudentManagement.Dto;
using StudentManagement.Model;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    public interface IDataAccessLayerService
    {
      
        //void DeleteStudent(int studentId);
     //   Task<IEnumerable<Address>> GetAllAddress(int studentId);
        
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetIdStudent(int studentId);
        Task<Student> AddStudent(Student student);
        Task<Address> StudentAddress(int studentId);
        Task<Student> Update(Student studentToUpdate);
        Task DeleteStudent(int studentId);
        Task<Course> AddCourse(Course course);
        Task<IEnumerable<Course>> GetAll();
        Task<IEnumerable<Marks>> GetStudentMark();
        Task<Marks>  AddMark(int studentId, int courseId, int grade);
        Task<Course> UpCourse(Course courseUpdate);
        Task<User> AddUser(User user);
        Task DeleteCourse(int courseId);
        Task<IEnumerable<Teachers>> GetTeacherInfo();
        Task<Teachers> AddTeacher(Teachers teachers);
        void Seed();
    }
}