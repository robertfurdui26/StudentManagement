using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dto
{
    public class CreateCourseDto
    {

        [Required]
         public string Name { get; set; }
    }
}
