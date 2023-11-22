﻿using Microsoft.AspNetCore.Mvc;
using StudentManagement.DAL;
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
        public IEnumerable<StudentGetDto> GetAllStudents()
        {
            var allStudents = dal.GetStudents();
            return allStudents.Select(s => StudentTransform.ToDto(s)).ToList();
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
        public StudentGetDto CreateStudent([FromBody] StudentCreateDto studentToCreate) =>
            dal.AddStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Update a student from db
        /// </summary>
        /// <param name="studentToUpdate">StudentId</param>
        /// <returns>New Student updated</returns>
        [HttpPatch("updateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentUpdateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public StudentGetDto UpdateStudent([FromBody] StudentUpdateDto studentToUpdate) =>
            dal.Update(studentToUpdate.ToEntity()).ToDto();


        /// <summary>
        /// Get Student by Id
        /// </summary>
        /// <param name="id">studentId</param>
        /// <returns>return a student from database by id</returns>
        [HttpGet("/getStudentById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public StudentGetDto GetStudentbyId(int id) =>
            dal.StudentById(id).ToDto();

        /// <summary>
        /// Delete a student 
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Student with id {id} will be removed from database </returns>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult DeleteAStudent(int id)
        {
            try
            {
                dal.DeleteStudent(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
