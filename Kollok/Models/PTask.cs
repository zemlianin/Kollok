using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Kollok.Models
{
    public class PTask
    {
        public int Id { get; set; }
        public string Describe { get; set; }
        public DateTime DeadLine { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }  
    }
}
