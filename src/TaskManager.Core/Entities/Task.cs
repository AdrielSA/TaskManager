namespace TaskManager.Core.Entities;

public partial class Task
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public string Status { get; set; } = null!;

    public int Priority { get; set; }
}
