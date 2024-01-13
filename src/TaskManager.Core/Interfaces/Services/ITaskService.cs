namespace TaskManager.Core.Interfaces.Services
{
    public interface ITaskService
    {
        void AddTask(Entities.Task task);
        void DeleteTask(int id);
        List<Entities.Task> GetTaskList();
        void UpdateTask(Entities.Task task);
    }
}