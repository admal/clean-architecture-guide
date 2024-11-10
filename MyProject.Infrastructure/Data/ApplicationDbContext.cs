using Microsoft.EntityFrameworkCore;
using MyProject.Application.Common.Interfaces;
namespace MyProject.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

}
