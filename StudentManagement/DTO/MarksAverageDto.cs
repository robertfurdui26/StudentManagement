using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTO
{
    public class MarksAverageDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }

        public double AverageTotal { get; set; }
    }
}
