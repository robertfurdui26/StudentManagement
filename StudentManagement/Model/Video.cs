using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Model
{
    public class Video
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public byte[] VideoData { get; set; }


    }
}
