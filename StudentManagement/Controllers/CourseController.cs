using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Dto;
using StudentManagement.Model;
using StudentManagement.Transform;
using System.Runtime.Serialization;
using System.Threading.Tasks;


namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public CourseController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Get Courses
        /// </summary>
        /// <returns></returns>
        [HttpGet("courses")]
        public async Task<IEnumerable<CourseGetDto>> GetAllCourse()
        {
            var allCourses = await dal.GetAll();
            return allCourses.Select(s => StudentTransform.ToDto(s)).ToList();
        }


        /// <summary>
        /// Create Course
        /// </summary>
        /// <param name="createCourseDto"></param>
        /// <returns></returns>
        [HttpPost("addCourse")]
        public async Task<ActionResult<CourseGetDto>> AddCourse([FromBody] CreateCourseDto createCourseDto)
        {
            try
            {
                var course = await dal.AddCourse(createCourseDto.ToEntity());
                var courseDto = StudentTransform.ToDto(course);
                return Ok(courseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Update Course
        /// </summary>
        /// <param name="courseUpdateDto"></param>
        /// <returns>Update a course from database with new property</returns>
        [HttpPut("updateCourse")]
        public async Task<ActionResult<CourseGetDto>> UpdateCourses([FromBody] CourseUpdateDto courseUpdateDto)
        {
            try
            {
                var course = await dal.UpCourse(courseUpdateDto.ToEntity());
                var courseDto = StudentTransform.ToDto(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// DeleteCourse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete a course from database from ID</returns>
        [HttpDelete("deleteCourse")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await dal.DeleteCourse(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

    
