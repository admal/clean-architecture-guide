namespace MyProject.Api.Models;

public class HomeChoreCreateModel
{
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsComplete { get; set; }
    public int Priority { get; set; }
}
