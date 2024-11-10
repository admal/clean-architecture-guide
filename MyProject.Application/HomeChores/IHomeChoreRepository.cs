using MyProject.Domain.Entities;

namespace MyProject.Application.HomeChores;

public interface IHomeChoreRepository
{
    Task<IList<HomeChore>> GetAllAsync();
    Task<HomeChore> GetByIdAsync(int id);
    Task AddAsync(HomeChore homeChore);
    Task UpdateAsync(HomeChore homeChore);
    Task DeleteAsync(int id);
}
