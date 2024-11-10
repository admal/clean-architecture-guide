using MyProject.Application.Common.Interfaces;
using MyProject.Application.HomeChores;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Repositories;

public class HomeChoreRepository : IHomeChoreRepository
{
    private IApplicationDbContext _db;

    public HomeChoreRepository(IApplicationDbContext db)
    {
        _db = db;
    }

    public Task AddAsync(HomeChore homeChore)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<HomeChore>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<HomeChore> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(HomeChore homeChore)
    {
        throw new NotImplementedException();
    }
}
