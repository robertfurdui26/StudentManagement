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

            ctx.TeachersDb.Add(new Teachers
            {
                Name = "Richard Oswolt",
                Age = 34,
                Description = "Study at Harvard,Sports,educated highly,determinated and love to play BasketBall"
            });

            ctx.TeachersDb.Add(new Teachers
            {
                Name = "Jhon Mayer",
                Age = 56,
                Description = "Study at Oxford,tecaher math,love math and algorithm"
            });



            ctx.SaveChanges();
        }
        #endregion

    }
}
