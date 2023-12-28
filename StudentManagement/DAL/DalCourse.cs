using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Dto;
using StudentManagement.Model;

namespace StudentManagement.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public async Task<IEnumerable<Course>> GetAll()
        {
          return await ctx.CoursesDb.ToListAsync();
        }

        public async Task<IEnumerable<VideoGetDto>> GetVideos()
        {
            var videos = await ctx.VideoDb.ToListAsync();

            return videos.Select(v => new VideoGetDto
            {
                Id = v.Id,
                Name = v.Name,
                Description = v.Description,
                VideoDataPath = $"api/Video/getVideos/{v.Id}" // Adjust the path/URL based on your requirements
            });
        }



        public async Task<Course> AddCourse(Course course)
        {
            if(ctx.CoursesDb.Any(s => s.Id == course.Id))
            {
                throw new Exception($"Course already exist ! {course}");
            }

            ctx.AddAsync(course);
            await ctx.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpCourse(Course courseUpdate)
        {
            var course = await ctx.CoursesDb.FirstOrDefaultAsync(s => s.Id == courseUpdate.Id);
            if (course == null)
            {
                throw new Exception($"Course not found{course}");
            }
            course.Name = courseUpdate.Name;
            ctx.SaveChanges();
            return course;
        }

        public async Task<Video>AddClip(Video videoDto)
        {
            var videoEntity = new Video
            {
                Name = videoDto.Name,
                Description = videoDto.Description,
                VideoData = videoDto.VideoData
            };

            await ctx.VideoDb.AddAsync(videoEntity);
            await ctx.SaveChangesAsync();
            return videoEntity;
        }
      


    }
}
