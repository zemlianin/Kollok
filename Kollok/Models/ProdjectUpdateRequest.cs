namespace Kollok.Models
{
    public class ProdjectUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public DateTime DeadLine { get; set; }
        public List<int> PeopleId { get; set; }
    }
}
