namespace workshop.wwwapi.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Person> People { get; set; } = [];
    }
}
