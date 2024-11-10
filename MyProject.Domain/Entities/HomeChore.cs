using MyProject.Domain.Enums;

namespace MyProject.Domain.Entities;

public class HomeChore
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsComplete { get; set; }
    public PriorityLevel? Priority { get; set; }
}
