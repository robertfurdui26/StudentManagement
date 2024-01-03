using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dto
{
    public class GetTeacherDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(90)]
        public int Age { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
