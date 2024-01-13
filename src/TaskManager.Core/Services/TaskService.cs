using TaskManager.Core.Interfaces.Repositories;
using TaskManager.Core.Interfaces.Services;

namespace TaskManager.Core.Services
{
    public class TaskService(IRepository<Entities.Task> repository) : ITaskService
    {
        private readonly IRepository<Entities.Task> _repository = repository;

        public List<Entities.Task> GetTaskList() =>
            _repository.GetAll().OrderByDescending(x => x.Priority).ToList();

        public void AddTask(Entities.Task task)
        {
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
            var task = _repository.GetById(id) ?? throw new Exception("Tarea no encontrada.");

            _repository.Delete(task);
            _repository.SaveChanges();
        }
    }
}
