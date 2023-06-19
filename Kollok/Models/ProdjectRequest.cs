namespace Kollok.Models
{
    public class ProdjectRequest
    {
        public string Name { get; set; }
        public string Describe { get; set; }
        public DateTime DeadLine { get; set; }
        public List<int> PeopleId { get; set; }
    }
}
