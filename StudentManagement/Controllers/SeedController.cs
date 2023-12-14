using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IDataAccessLayerService _dal;

        public SeedController(IDataAccessLayerService dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// Seed data base with dummy data
        /// </summary>
        [HttpPost]
        public void Seed() => _dal.Seed();
    }
}
