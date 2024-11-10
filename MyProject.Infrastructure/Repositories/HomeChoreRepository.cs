using Microsoft.EntityFrameworkCore;
using MyProject.Application.Common.Interfaces;
using MyProject.Application.HomeChores;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Repositories;

public class HomeChoreRepository : IHomeChoreRepository
{
    private readonly IApplicationDbContext _db;

    public HomeChoreRepository(IApplicationDbContext context)
    {
        _db = context;
    }

    public async Task<IList<HomeChoreDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.HomeChores
            .Select(h => new HomeChoreDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                DueDate = h.DueDate ?? DateTime.MinValue,
                IsCompleted = h.IsComplete
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<HomeChoreDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var homeChore = await _db.HomeChores.FindAsync(id, cancellationToken);
        if (homeChore == null)
        {
            return null;
        }

        return new HomeChoreDto
        {
            Id = homeChore.Id,
            Name = homeChore.Name,
            Description = homeChore.Description,
            DueDate = homeChore.DueDate ?? DateTime.MinValue,
            IsCompleted = homeChore.IsComplete
        };
    }

    public async Task AddAsync(HomeChoreDto homeChoreDto, CancellationToken cancellationToken)
    {
        var homeChore = new HomeChore
        {
            Name = homeChoreDto.Name,
            Description = homeChoreDto.Description,
            DueDate = homeChoreDto.DueDate,
            IsComplete = homeChoreDto.IsCompleted
        };

        _db.HomeChores.Add(homeChore);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(HomeChoreDto homeChoreDto, CancellationToken cancellationToken)
    {
        var homeChore = await _db.HomeChores.FindAsync(homeChoreDto.Id, cancellationToken);
        if (homeChore == null)
        {
            return;
        }

        homeChore.Name = homeChoreDto.Name;
        homeChore.Description = homeChoreDto.Description;
        homeChore.DueDate = homeChoreDto.DueDate;
        homeChore.IsComplete = homeChoreDto.IsCompleted;

        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var homeChore = await _db.HomeChores.FindAsync(id, cancellationToken);
        if (homeChore == null)
        {
            return;
        }

        _db.HomeChores.Remove(homeChore);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
