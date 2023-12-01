using Bogus;
using Microsoft.AspNetCore.Identity;
using Model;

namespace ExamCCI_2023.Service
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            if (!context.Students.Any())
            {
                var _Faker = new Faker<Student>();
                _Faker.RuleFor(p => p.Firstname, f => f.Person.FirstName);
                _Faker.RuleFor(p => p.Lastname, f => f.Person.LastName);
                //_Faker.RuleFor(p => p.DateOfBirth, f => f.Date);

                var studentList = _Faker.Generate(30);

                await context.Students.AddRangeAsync(studentList);
                await context.SaveChangesAsync();
            }
        }
    }

}
