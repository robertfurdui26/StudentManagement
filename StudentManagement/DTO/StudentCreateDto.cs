using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTO
{
    public class StudentCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
