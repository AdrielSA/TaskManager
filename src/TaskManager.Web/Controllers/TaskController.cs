using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Interfaces.Services;
using TaskManager.Web.Models;

namespace TaskManager.Web.Controllers
{
    public class TaskController(ITaskService taskService, IMapper mapper) : Controller
    {
        private readonly ITaskService _taskService = taskService;
        private readonly IMapper _mapper = mapper;


        public IActionResult Index()
        {
            var tasks = _mapper.Map<List<TaskViewModel>>(_taskService.GetTaskList());
            return View(tasks);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(TaskViewModel model)
        {
            _taskService.AddTask(_mapper.Map<Core.Entities.Task>(model));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var task = _mapper.Map<TaskViewModel>(_taskService.GetTaskById(id));
            return View(task);
        }

        [HttpPut]
        public IActionResult Edit(TaskViewModel model)
        {
            var task = _taskService.GetTaskById(model.Id.GetValueOrDefault());
            task = _mapper.Map(model, task);
            _taskService.UpdateTask(task);
            return Json($"/Task/{nameof(Index)}");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id);
            return Json($"/Task/{nameof(Index)}");
        }
    }
}
