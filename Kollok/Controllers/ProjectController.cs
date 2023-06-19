using Kollok.Models;
using Kollok.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kollok.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {

        private readonly ILogger<ProjectController> _logger;

        private readonly ApplicationContext _context;

        public ProjectController(ILogger<ProjectController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("create-prodject")]
        public async Task<ActionResult> CreateProdject(ProdjectRequest prodjectRequest)
        {
            var list = _context.People.Where(a => prodjectRequest.PeopleId.Contains(a.Id)).ToList();
            var project = new Project()
            {
                Name = prodjectRequest.Name,
                DeadLine = prodjectRequest.DeadLine,
                Describe = prodjectRequest.Describe,
                People = list,
                Exist = true
            };
            _context.Projects.Add(project);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("get-list-prodjects")]
        public async Task<ActionResult<IList<ProjectListResponse>>> Get()
        {
            var prodjects = _context.Projects.Where(a => a.Exist).ToList();
            var responseList = new List<ProjectListResponse>();
            foreach (var prodject in prodjects)
            {
                var members = _context.People.Where(a => a.ProjectId == prodject.Id);
                var membersId = new List<int>();
                foreach (var member in members)
                {
                    membersId.Add(member.Id);
                }
                responseList.Add(new ProjectListResponse()
                {
                    Name = prodject.Name,
                    DeadLine = prodject.DeadLine,
                    Describe = prodject.Describe,
                    People = membersId
                });
            }

            return Ok(responseList);
        }

        [HttpGet]
        [Route("get-one-prodlect")]
        public async Task<ActionResult<ProdjectResponse>> GetProdject(int id)
        {
            var prodject = _context.Projects.Where(a => a.Exist).FirstOrDefault(a => a.Id == id);
            if (prodject == null)
            {
                return NotFound();
            }
            var members = _context.People.Where(a => a.ProjectId == prodject.Id);
            var membersId = new List<int>();
            foreach (var member in members)
            {
                membersId.Add(member.Id);
            }

            var pTasks = _context.PTasks.Where(a => a.ProjectId == prodject.Id);
            var pTasksId = new List<int>();
            foreach (var pTask in pTasks)
            {
                pTasksId.Add(pTask.Id);
            }
            var response = new ProdjectResponse()
            {
                Name = prodject.Name,
                DeadLine = prodject.DeadLine,
                Describe = prodject.Describe,
                People = membersId,
                PTasks = pTasksId
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateProdject(ProdjectUpdateRequest prodjectRequest)
        {
            var prodject = _context.Projects.Where(a => a.Exist).FirstOrDefault(a => a.Id == prodjectRequest.Id);
            if (prodject == null)
            {
                return NotFound();
            }

            var members = _context.People.Where(a => prodjectRequest.PeopleId.Contains(a.Id)).ToList();

            var pTasks = _context.PTasks.Where(a => a.ProjectId == prodject.Id).ToList();

            prodject.Id = prodjectRequest.Id;
            prodject.Name = prodjectRequest.Name;
            prodject.DeadLine = prodjectRequest.DeadLine;
            prodject.Describe = prodjectRequest.Describe;
            prodject.People = members;
            prodject.PTasks = pTasks;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("delete-one-prodlect")]
        public async Task<ActionResult> DeleteProdject(int id)
        {
            var prodject = _context.Projects.Where(a => a.Exist).FirstOrDefault(a => a.Id == id);
            if (prodject == null)
            {
                return NotFound();
            }

            prodject.Exist = false;
            _context.SaveChanges();
            return Ok();
        }
    }
}