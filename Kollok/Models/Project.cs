namespace Kollok.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public DateTime DeadLine { get; set; }
        public List<PTask> PTasks { get; set; } = new();
        public List<Person> People { get; set; } = new();
        public bool Exist { get; set; }
    }
}
