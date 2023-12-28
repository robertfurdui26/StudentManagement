using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Dto
{
    public class VideoAddDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public IFormFile VideoData { get; set; }
    }
}
