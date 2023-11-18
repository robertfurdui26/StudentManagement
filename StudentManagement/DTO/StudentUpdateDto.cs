using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTO
{
    public class StudentUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
