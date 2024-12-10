using MyProject.Application.Common;
using MyProject.Application.HomeChores.Dto;

namespace MyProject.Application.HomeChores;

public class HomeChoreService : IHomeChoreService
{
    private readonly IHomeChoreRepository _homeChoreRepository;

    public HomeChoreService(IHomeChoreRepository homeChoreRepository)
    {
        _homeChoreRepository = homeChoreRepository;
    }

    public async Task<IList<HomeChoreDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _homeChoreRepository.GetAll(cancellationToken);
    }

    public async Task<ServiceResult<HomeChoreDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var homeChore = await _homeChoreRepository.GetById(id, cancellationToken);

        return homeChore == null
            ? ServiceResult<HomeChoreDto>.ForError("Home chore not found.")
            : ServiceResult<HomeChoreDto>.ForSuccess(homeChore);
    }

    public async Task<ServiceResult> Create(HomeChoreCreateDto homeChore, CancellationToken cancellationToken)
    {
        if (homeChore.DueDate < DateTime.Now)
        {
            return ServiceResult.ForError("Due date must be in the future.");
        }

        await _homeChoreRepository.Create(homeChore, cancellationToken);
        return ServiceResult.ForSuccess();
    }
}

public interface IHomeChoreService
{
    Task<IList<HomeChoreDto>> GetAll(CancellationToken cancellationToken);
    Task<ServiceResult<HomeChoreDto>> GetById(int id, CancellationToken cancellationToken);
    Task<ServiceResult> Create(HomeChoreCreateDto homeChore, CancellationToken cancellationToken);
}
