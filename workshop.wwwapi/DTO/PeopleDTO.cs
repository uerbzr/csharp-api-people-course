namespace workshop.wwwapi.DTO
{
    /// <summary>
    /// DTO for collection of People DTO's
    /// </summary>
    public class PeopleDTO
    {
        public List<PersonDTO> People { get; set; } = new List<PersonDTO>();
    }
}
