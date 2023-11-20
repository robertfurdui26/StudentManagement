namespace StudentManagement.Model
{
    public class Teachers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Student Student { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Marks> Mark { get; set; } = new List<Marks>();
    }
}
