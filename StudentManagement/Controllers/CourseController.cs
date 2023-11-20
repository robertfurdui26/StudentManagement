using Microsoft.AspNetCore.Mvc;
using StudentManagement.DAL;
using StudentManagement.Data;
using StudentManagement.DTO;
using StudentManagement.Model;

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
        ///  Create course for student
        /// </summary>
        /// <param name="courseName">courseDto</param>
        /// <returns>We create a new course and store this course in database</returns>
        [HttpPost("addCourse")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public IActionResult CreateCourse([FromBody] string courseName)
        {
            try
            {
                var course = dal.AddCourse(courseName);
                return Ok(course);
            }
            catch (Exception ex)
            {             
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns>Extract all courses from database</returns>
        [HttpGet("getCourses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentUpdateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        public List<Course> GetAllCourses() => dal.GetCourses();
    }
}
