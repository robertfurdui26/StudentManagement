using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dto
{
    public class CourseGetDto
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
