using MyProject.Application.HomeChores.Dto;

namespace MyProject.Application.HomeChores;

public interface IHomeChoreRepository
{
    Task<IList<HomeChoreDto>> GetAll(CancellationToken cancellationToken);
    Task<HomeChoreDto?> GetById(int id, CancellationToken cancellationToken);
    Task Create(HomeChoreCreateDto homeChore, CancellationToken cancellationToken);
}
