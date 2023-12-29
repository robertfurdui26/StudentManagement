using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; }

        public double StudentTotalAverage { get; set; }

        public double CalculateTotalAverage()
        {
            if (Marks.Any())
            {
                return Marks.Average(n => n.Grade);
            }

            return 0;
        }

        public List<Course> Courses { get; set; } = new List<Course>();

        public List<Marks> Marks { get; set; } = new List<Marks>();

       
    }

}
