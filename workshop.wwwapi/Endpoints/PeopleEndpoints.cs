using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PeopleEndpoints
    {
        public static void Configure(this WebApplication app)
        {
            var people = app.MapGroup("/people");



        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPets(IRepository repository)
        {
            var results = await repository.GetAll();
            return TypedResults.Ok(results);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddPet(IRepository repository, PersonPost model)
        {
            try
            {

                Person person = new Person()
                {
                    Name = model.Name,                   
                    Age = model.Age
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
        public static async Task<IResult> DeletePerson(IRepository repository, int id)
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
        public static async Task<IResult> UpdatePerson(IRepository repository, int id, PersonPut model)
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
