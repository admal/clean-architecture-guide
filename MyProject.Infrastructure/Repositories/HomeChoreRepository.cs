using Microsoft.EntityFrameworkCore;
using MyProject.Application.Common.Interfaces;
using MyProject.Application.HomeChores;
using MyProject.Application.HomeChores.Dto;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Repositories;

public class HomeChoreRepository : IHomeChoreRepository
{
    private readonly IApplicationDbContext _db;

    public HomeChoreRepository(IApplicationDbContext context)
    {
        _db = context;
    }

    public async Task<IList<HomeChoreDto>> GetAll(CancellationToken cancellationToken)
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

    public async Task<HomeChoreDto?> GetById(int id, CancellationToken cancellationToken)
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

    public async Task Create(HomeChoreCreateDto homeChoreDto, CancellationToken cancellationToken)
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
}
