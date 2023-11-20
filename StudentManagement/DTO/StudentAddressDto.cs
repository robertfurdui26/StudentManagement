using System.ComponentModel.DataAnnotations;

namespace StudentManagement.DTO
{
    public class StudentAddressDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int Number { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }

    }
}
