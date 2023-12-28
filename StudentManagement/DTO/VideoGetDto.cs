using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Dto
{
    public class VideoGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public IFormFile VideoData { get; set; }

        public string VideoDataPath { get; set; }
    }
}
