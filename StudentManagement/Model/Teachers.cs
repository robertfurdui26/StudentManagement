using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Model
{
    public class Teachers
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Marks> Mark { get; set; } = new List<Marks>();
    }
}
