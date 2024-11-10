using MyProject.Domain.Enums;

namespace MyProject.Application.HomeChores.Dto;

public class HomeChoreDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public PriorityLevel Priority { get; set; }
}
