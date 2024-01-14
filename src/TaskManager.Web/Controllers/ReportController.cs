using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TaskManager.Core.Interfaces.Services;

namespace TaskManager.Web.Controllers
{
    public class ReportController(ITaskService taskService, IWebHostEnvironment hostEnvironment) : Controller
    {
        private readonly ITaskService _taskService = taskService;
        private readonly IWebHostEnvironment _hostEnvironment = hostEnvironment; 

        public IActionResult Index()
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "report", "TaskManagerReport.rdlc");
            var report = new LocalReport(path);

            var tasks = _taskService.GetTaskList();
            report.AddDataSource("TaskDataset", tasks);

            var result = report.Execute(RenderType.Pdf);

            return File(result.MainStream, MediaTypeNames.Application.Json);
        }
    }
}
