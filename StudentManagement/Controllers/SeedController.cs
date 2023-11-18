using Microsoft.AspNetCore.Mvc;
using StudentManagement.DAL;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly DataAccessLayerService _dal;

        public SeedController(DataAccessLayerService dal)
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
