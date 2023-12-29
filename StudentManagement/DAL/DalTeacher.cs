using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Model;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StudentManagement.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        
        public async Task<IEnumerable<Teachers>> GetTeacherInfo()
        {
            return await ctx.TeachersDb.ToListAsync();
        }

        public async Task<Teachers> AddTeacher (Teachers teachers)
        {
            if(ctx.TeachersDb.Any(s => s.Id == teachers.Id))
            {
                throw new Exception($"Teacher already exist{teachers.Name}");
            }
            ctx.TeachersDb.AddAsync(teachers);
            await ctx.SaveChangesAsync();
            return teachers;
        }

    }
}
