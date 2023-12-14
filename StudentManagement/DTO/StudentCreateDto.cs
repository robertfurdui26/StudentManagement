using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTO
{
    public class StudentCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,100)]
        public int Age { get; set; }
    }
}
