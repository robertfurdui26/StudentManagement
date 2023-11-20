namespace StudentManagement.Model
{
    public class Marks
    {
        public int Id { get; set; }

        public int Grade { get; set; }

        public DateTime DataGrade { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }

        public Student Student { get; set; }

        public int StudentId { get; set; }

        public double AverageTotal { get; set; }
    }
}
