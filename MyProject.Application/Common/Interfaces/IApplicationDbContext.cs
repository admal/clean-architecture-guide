using Microsoft.EntityFrameworkCore;
using MyProject.Domain.Entities;

namespace MyProject.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<HomeChore> HomeChores { get; }
}
