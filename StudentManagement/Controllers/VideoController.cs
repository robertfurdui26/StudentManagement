using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Dto;
using StudentManagement.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public VideoController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Add Video
        /// </summary>
        /// <param name="videoDto"></param>
        /// <returns></returns>
        [HttpPost("addVideo")]
        public async Task<ActionResult<Video>> AddVideo([FromForm] VideoAddDto videoDto)
        {
            try
            {
                if (videoDto.VideoData == null || videoDto.VideoData.Length == 0)
                {
                    return BadRequest("No video file provided");
                }

                using (var memoryStream = new MemoryStream())
                {
                    await videoDto.VideoData.CopyToAsync(memoryStream);
                    var videoData = memoryStream.ToArray();

                    var addedVideo = await dal.AddClip(new Video
                    {
                        Name = videoDto.Name,
                        Description = videoDto.Description,
                        VideoData = videoData
                    });

                    return Ok(addedVideo);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        /// <summary>
        /// get video
        /// </summary>
        /// <returns></returns>
        [HttpGet("getVideos")]
        public async Task<ActionResult<IEnumerable<VideoGetDto>>> GetVideos()
        {
            try
            {
                var videos = await dal.GetVideos();

                if (videos == null || !videos.Any())
                {
                    return NotFound("No videos found");
                }


                return Ok(videos);
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate error response
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
