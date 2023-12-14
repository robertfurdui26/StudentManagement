 using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.DTO;
using StudentManagement.Transform;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public StudentController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// All Students from database
        /// </summary>
        /// <returns></returns>       
        [HttpGet("getAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(string))]
        public async Task<IEnumerable<StudentGetDto>> GetAllStudents()
        {
            var allStudents =  await dal.GetAllStudents();
            return allStudents.Select(s => StudentTransform.ToDto(s)).ToList();
        }

        /// <summary>
        /// Get Student by Id
        /// </summary>
        /// <param name="id">studentId</param>
        /// <returns>return a student from database by id</returns>
        [HttpGet("/getStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<StudentGetDto>> GetStudentId(int studentId)
        {
            try
            {
                var student = await dal.GetIdStudent(studentId);
                var studentDto = StudentTransform.ToDto(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create a new Student
        /// </summary>
        /// <param name="studentToCreate">studentToCreate</param>
        /// <returns>A new Student</returns>
        [HttpPost("createStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentCreateDto))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<ActionResult<StudentGetDto>> CreateStudent([FromBody] StudentCreateDto studentToCreate)
        {
            try
            {
                var addedStudent = await dal.AddStudent(studentToCreate.ToEntity());
                var studentDto = StudentTransform.ToDto(addedStudent);
                return Ok(studentDto);
            }catch (Exception ex)
            {
               return  BadRequest(ex.Message);
            }
        }
        //background-image: url('./images/holybg.jpg');

        /// <summary>
        /// GetStudent Address
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("studentAddress")]
        public async Task<ActionResult<StudentAddressDto>> GetStudentAddress(int studentId)
        {
            try
            {
                var studentAddress = await dal.StudentAddress(studentId);
                var studentDtoAddress = StudentTransform.ToDto(studentAddress);
                return Ok(studentDtoAddress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update a student from db
        /// </summary>
        /// <param name="studentToUpdate">StudentId</param>
        /// <returns>New Student updated</returns>
        [HttpPatch("updateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentUpdateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<ActionResult<StudentGetDto>> UpdateStudent([FromBody] StudentUpdateDto studentToUpdate)
        {
            try
            {
                var student = await dal.Update(studentToUpdate.ToEntity());
                var studentDto = StudentTransform.ToDto(student);
                return Ok(studentDto);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }     

        /// <summary>
        /// Delete a student 
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Student with id {id} will be removed from database </returns>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> DeleteAStudent(int id)
        {
            try
            {
               await dal.DeleteStudent(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
