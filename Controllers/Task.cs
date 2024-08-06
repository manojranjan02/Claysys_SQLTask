using Claysys_SQLTask.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Claysys_SQLTask.Models.TaskModel;

namespace Claysys_SQLTask.Controllers
{
    public class Task : Controller
    {
        private readonly TaskRepo _repo;
        public Task(TaskRepo taskRepo)
        {
            _repo = taskRepo;
        }
        [Authorize(Roles = "User")]
        [Route("TaskTracker")]
        public IActionResult TaskTracker()
        {
            return View();
        }
        [Route("api/data/clients")]
        public IActionResult GetClients()
        {
            return Ok(_repo.GetClients());
        }

        [Route("api/data/projects/{clientId}")]
        public IActionResult GetProjects(int clientId)
        {
            return Ok(_repo.GetProjects(clientId));
        }

        [Route("Home")]
        public IActionResult Home()
        {
            return View();
        }
    }
}
