using MyProject.Domain.Entities;

namespace MyProject.Application.HomeChores;

public interface IHomeChoreRepository
{
    Task<IList<HomeChoreDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<HomeChoreDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(HomeChoreDto homeChore, CancellationToken cancellationToken);
}

public class HomeChoreDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}
