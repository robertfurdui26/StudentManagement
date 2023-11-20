using Microsoft.AspNetCore.Mvc;
using StudentManagement.DAL;
using StudentManagement.DTO;
using StudentManagement.Model;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly DataAccessLayerService dal;
        public MarksController(DataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Add student grade for a course
        /// </summary>
        /// <param name="mark">mark</param>
        /// <return>We add a grade to a course for a student</return>
        [HttpPost("addMark")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        public void AddMarkForAStudent([FromBody] MarkAddDto mark) =>
            dal.AddMark(mark.Grade, mark.StudentId, mark.CourseId);

        /// <summary>
        /// Get all marks from database
        /// </summary>
        /// <returns>A list of all students grades for each course</returns>
        [HttpGet("getMarks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]

        public List<Marks> GetMarksStudents() => dal.GetAllMarks();

        /// <summary>
        ///  Get student average for a course
        /// </summary>
        /// <param name="studentId">studentId</param>
        /// <param name="courseId">courseId</param>
        /// <returns>Course average for a student </returns>
        [HttpGet("getAveragePerSubject")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public ActionResult<IEnumerable<MarksAverageDto>> GetAveragePerSbj(int studentId, int courseId)
        {
            var averageList = dal.GetAverage(studentId, courseId);

            if (averageList != null && averageList.Any())
            {
                var average = averageList.First().AverageTotal;

                var averageDtoList = new List<MarksAverageDto>
                {
            new MarksAverageDto
            {
                AverageTotal = average,
                CourseId = courseId,
                StudentId = studentId
            }
                };

                return Ok(averageDtoList);
            }
            else
            {
                return NotFound("No data found");
            }
        }
    }
}
