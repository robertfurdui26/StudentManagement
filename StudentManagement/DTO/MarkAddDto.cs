using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTO
{
    public class MarkAddDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [Range(1,10)]
        public int Grade { get; set; }
        [Required]
        public DateTime DataGrade { get; set; }




    }
}
