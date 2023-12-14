using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dto
{
    public class CourseUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
