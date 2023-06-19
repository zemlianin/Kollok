namespace Kollok.Models
{
    public class PTaskRequest
    {
        public string Describe { get; set; }
        public DateTime DeadLine { get; set; }
        public int ProjectId { get; set; }
    }
}
