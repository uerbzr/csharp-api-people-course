namespace workshop.wwwapi.DTO
{
    /// <summary>
    /// DTO for a Person
    /// </summary>
    public class PersonDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public List<string> Courses { get; set; } = new List<string>();
    }
}
