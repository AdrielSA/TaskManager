namespace TaskManager.Web.Models
{
    public record TaskViewModel
    (
        int? Id, 
        string Description, 
        DateTime CreationDate, 
        string Status, 
        int Priority
    );
}
