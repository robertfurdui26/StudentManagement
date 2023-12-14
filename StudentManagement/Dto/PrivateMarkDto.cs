using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dto
{
    public class PrivateMarkDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [Range(1, 10)]
        public int Grade { get; set; }
    }
}
