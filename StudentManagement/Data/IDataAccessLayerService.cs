using StudentManagement.Model;

namespace StudentManagement.Data
{
    public interface IDataAccessLayerService
    {
        void Seed();
        void DeleteStudent(int studentId);
        void AddMark(int grade, int studentId, int courseId);
        Address StudentAddress(int studentId);
        Student AddStudent(Student student);
        List<Marks> GetAllMarks();
        List<Marks> GetAverage(int studentId, int courseId);
        List<Course> GetCourses();
        Course AddCourse(string nameCourse);
        IEnumerable<Student> GetStudentByAverageOrder();
        IEnumerable<Student> GetStudents();
        Student StudentById(int id);
        Student Update(Student studentToUpdate);
    }
}