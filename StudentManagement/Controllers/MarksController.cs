using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Dto;
using StudentManagement.DTO;
using StudentManagement.Model;
using StudentManagement.Transform;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public MarksController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }


        

        /// <summary>
        /// GetGrades
        /// </summary>
        /// <returns></returns>
        [HttpGet("marks")]
        public async Task<IEnumerable<GetMarksDto>> GetMarks()
        {
            var marks = await dal.GetStudentMark();
            return marks.Select(s => StudentTransform.ToDto(s)).ToList();
            
        }


        /// <summary>
        /// Add Mark
        /// </summary>
        /// <param name="marks"></param>
        /// <returns></returns>
        [HttpPost("addMarks")]
        public async Task<Marks> AddMarkForAStudent([FromBody] MarkAddDto marks)
        {
          return await dal.AddMark( marks.StudentId , marks.CourseId, marks.Grade);                 
        }
       


     
    }
}
