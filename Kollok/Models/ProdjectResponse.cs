namespace Kollok.Models
{
    public class ProdjectResponse
    {
        public string Name { get; set; }
        public string Describe { get; set; }
        public DateTime DeadLine { get; set; }
        public List<int> People { get; set; }
        public List<int> PTasks { get; set; }
    }
}
