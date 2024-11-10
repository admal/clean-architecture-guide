using MyProject.Application.Common;

namespace MyProject.Application.HomeChores;

public class HomeChoreService : IHomeChoreService
{
    private readonly IHomeChoreRepository _homeChoreRepository;

    public HomeChoreService(IHomeChoreRepository homeChoreRepository)
    {
        _homeChoreRepository = homeChoreRepository;
    }

    public async Task<IList<HomeChoreDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _homeChoreRepository.GetAllAsync(cancellationToken);
    }

    public async Task<ServiceResult<HomeChoreDto>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var homeChore = await _homeChoreRepository.GetByIdAsync(id, cancellationToken);

        return homeChore == null
            ? ServiceResult<HomeChoreDto>.ForError("Home chore not found.")
            : ServiceResult<HomeChoreDto>.ForSuccess(homeChore);
    }

    public async Task<ServiceResult> AddAsync(HomeChoreDto homeChore, CancellationToken cancellationToken)
    {
        if (homeChore.DueDate >= DateTime.Now)
        {
            return ServiceResult.ForError("Due date must be in the future.");
        }

        await _homeChoreRepository.AddAsync(homeChore, cancellationToken);
        return ServiceResult.ForSuccess();
    }
}

public interface IHomeChoreService
{
    Task<IList<HomeChoreDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<ServiceResult<HomeChoreDto>> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<ServiceResult> AddAsync(HomeChoreDto homeChore, CancellationToken cancellationToken);
}
