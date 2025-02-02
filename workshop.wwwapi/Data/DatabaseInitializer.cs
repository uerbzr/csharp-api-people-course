using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public static class DatabaseInitializer
    {
        public async static Task<WebApplication> Seed(this WebApplication app)
        {
            
            using (var scope = app.Services.CreateScope())
            {

                using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                try
                {
                    
                    context.Database.EnsureCreated();

                    if (!context.Offices.Any())
                    {
                        context.Offices.AddRange(
                            new List<Office>()
                            {
                                new Office(){ Location = "New York" },
                                new Office(){ Location = "London" },
                                new Office(){ Location = "Tokyo" },
                            }
                        );

                    }
                    PeopleData peopleData = new PeopleData();
                    if (!context.People.Any())
                    {
                        //await context.People.AddRangeAsync(peopleData.People);
                        Person person = new Person() { Id = 1, Name = "Nigel", Age = 21, Email = "nigel@nigel.nigel", OfficeId = 1 };
                        await context.People.AddAsync(person);
                        
                    }
                    if(!context.Courses.Any())
                    {
                        CourseData courseData = new CourseData();
                        await context.Courses.AddRangeAsync(courseData.Courses);
                        
                    }
                    if(!context.CoursePerson.Any())
                    {
                        await context.CoursePerson.AddRangeAsync(
                            new List<CoursePerson>()
                            {
                                new CoursePerson(){ CourseId=1, PersonId=1 },
                              

                            }
                        );
                    }
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return app;

        }
    }
}
