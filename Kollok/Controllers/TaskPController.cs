using Kollok.Models;
using Kollok.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kollok.Controllers
{
    public class TaskPController : Controller
    {

        private readonly ILogger<ProjectController> _logger;

        private readonly ApplicationContext _context;

        public TaskPController(ILogger<ProjectController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }



        [HttpPost]
        [Route("create-pTask")]
        public async Task<ActionResult> CreatePTask(PTaskRequest request)
        {
            var project = _context.Projects.Where(a => a.Exist).FirstOrDefault(a => a.Id == request.ProjectId);
            var pTask = new PTask()
            {
                DeadLine = request.DeadLine,
                Describe = request.Describe,
                Project = project
            };
            _context.PTasks.Add(pTask);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("get-list-pTasks")]
        public async Task<ActionResult<IList<Project>>> GetAllProject()
        {
            var pTasks = _context.PTasks.ToList();


            return Ok(pTasks);
        }
    }
}
