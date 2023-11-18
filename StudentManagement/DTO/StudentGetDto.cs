using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTO
{
    public class StudentGetDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public int Age { get; set; }
    }
}
