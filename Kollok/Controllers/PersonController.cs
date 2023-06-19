using Kollok.Models;
using Kollok.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kollok.Controllers
{
    public class PersonController : Controller
    {

        private readonly ILogger<ProjectController> _logger;

        private readonly ApplicationContext _context;

        public PersonController(ILogger<ProjectController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpPost]
        [Route("create-person")]
        public async Task<ActionResult> CreatePeople(string name, int ProjectId)
        {
            var project = _context.Projects.Where(a => a.Exist).FirstOrDefault(a => a.Id == ProjectId);
            var person = new Person()
            {
                Name = name,
                Project = project
            };
            _context.People.Add(person);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("get-list-people")]
        public async Task<ActionResult<IList<Project>>> GetAllProject()
        {
            var people = _context.People.ToList();

            return Ok(people);
        }
    }
}
