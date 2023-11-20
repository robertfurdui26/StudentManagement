using Microsoft.AspNetCore.Mvc;
using StudentManagement.DAL;
using StudentManagement.DTO;
using StudentManagement.Transform;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DataAccessLayerService dal;

        public AddressController(DataAccessLayerService dal)
        {
            this.dal = dal;
        }


        /// <summary>
        /// Get Student Adddress
        /// </summary>
        /// <param name="id">studentId</param>
        /// <returns>Return address for a student and if id is null it will throw an error</returns>
        [HttpGet("address{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentAddressDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public StudentAddressDto GetStudentAddress(int id) =>
            dal.StudentAddress(id).ToDto();
        

        
    }
}
