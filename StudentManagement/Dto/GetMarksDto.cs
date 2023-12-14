using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dto
{
    public class GetMarksDto
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int CourseId { get; set; }
        public int Grade { get; set; }
        public DateTime DataGrade { get; set; }
    }
}
