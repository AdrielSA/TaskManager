using TaskManager.Core.Interfaces.Repositories;
using TaskManager.Core.Interfaces.Services;

namespace TaskManager.Core.Services
{
    public class TaskService(IRepository<Entities.Task> repository) : ITaskService
    {
        private readonly IRepository<Entities.Task> _repository = repository;

        public List<Entities.Task> GetTaskList() =>
            _repository.GetAll().OrderByDescending(x => x.Priority).ToList();

        public Entities.Task GetTaskById(int id) =>
            _repository.GetById(id) ?? throw new Exception("Tarea no encontrada.");

        public void AddTask(Entities.Task task)
        {
            task.CreationDate = DateTime.Now;

            _repository.Add(task);
            _repository.SaveChanges();
        }

        public void UpdateTask(Entities.Task task)
        {
            _repository.Update(task);
            _repository.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);

            _repository.Delete(task);
            _repository.SaveChanges();
        }
    }
}
