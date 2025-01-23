using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PeopleEndpoints
    {
        public static void ConfigurePeople(this WebApplication app)
        {
            var people = app.MapGroup("/people");

            people.MapGet("/", GetAll);
            people.MapPost("/", Add);
            people.MapDelete("/{id}", Delete);
            people.MapPut("/{id}", Update);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository repository)
        {
            Payload<List<Person>> payload = new Payload<List<Person>>();


            var results = await repository.GetAll();
            payload.Data = results.ToList();

            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> Add(IRepository repository, PersonPost model)
        {
            try
            {

                Person person = new Person()
                {
                    Name = model.Name,                   
                    Age = model.Age,
                    Email = model.Email
                };
                await repository.Add(person);

                return TypedResults.Created($"https://localhost:7010/people/{person.Id}", person);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(IRepository repository, int id)
        {
            try
            {
                var model = await repository.Get(id);
                if (await repository.Delete(id)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Name = model.Name, Age = model.Age });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(IRepository repository, int id, PersonPut model)
        {
            try
            {
                var target = await repository.Get(id);
                if (target == null) return Results.NotFound();
                if (model.Name != null) target.Name = model.Name;             
                if (model.Age != null) target.Age = model.Age.Value;
                return Results.Ok(target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
