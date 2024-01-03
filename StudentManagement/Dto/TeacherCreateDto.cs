using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dto
{
    public class TeacherCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
