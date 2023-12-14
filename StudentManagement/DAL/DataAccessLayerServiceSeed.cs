using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Model;

namespace StudentManagement.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {

        #region Seed
        public void Seed()
        {
            ctx.Add(new Student
            {
                Name = "Robert",
                Age = 54,
                Address = new Address
                {
                    Number = 43,
                    Street = "Alea Parc",
                    City = "Oradea"
                }
            });

            ctx.Add(new Student
            {
                Name = "Marian",
                Age = 34,
                Address = new Address
                {
                    Number = 88,
                    Street = "Gheorghiu Dej",
                    City = "Sebes"
                }
            });

            ctx.Add(new Student
            {
                Name = "Octavian",
                Age = 23,
                Address = new Address
                {
                    Number = 12,
                    Street = "Maniu ",
                    City = "Mures"
                }
            });

            ctx.CoursesDb.Add(new Course
            { 
                Name = "Matematica"

            });

            ctx.CoursesDb.Add(new Course
            {
                Name = "Romana"

            });

            ctx.CoursesDb.Add(new Course
            {
                Name = "Engleza"

            });

           

            ctx.SaveChanges();
        }
        #endregion

    }
}
