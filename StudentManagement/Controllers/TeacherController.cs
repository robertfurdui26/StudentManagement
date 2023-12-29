using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Dto;
using StudentManagement.DTO;
using StudentManagement.Transform;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;

        public TeacherController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Get All Teacher
        /// </summary>
        /// <returns>Teacher seeded from database</returns>
        [HttpGet("getTeacherInfo")]
        public async Task<IEnumerable<GetTeacherDto>> GetTeacher()
        {
           var allTeacher = await dal.GetTeacherInfo();
            return allTeacher.Select(s => StudentTransform.ToDto(s)).ToList();

        }

        /// <summary>
        /// create teacher
        /// </summary>
        /// <param name="teacherCreate"></param>
        /// <returns></returns>
        [HttpPost("addTeacher")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherCreateDto))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<GetTeacherDto>> CreateStudent([FromBody] TeacherCreateDto teacherCreate)
        {
            try
            {
                var addedTeacher = await dal.AddTeacher(teacherCreate.ToEntity());
                var studentDto = StudentTransform.ToDto(addedTeacher);
                return Ok(studentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
