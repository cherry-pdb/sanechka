using Microsoft.EntityFrameworkCore;
using TerminationSystem.Models;

namespace TerminationSystem.Data;

public class TerminationDbContext : DbContext
{
    public DbSet<TerminationRecord> Terminations { get; init; } = null!;
    
    public TerminationDbContext()
    {
    }
    
    public TerminationDbContext(DbContextOptions<TerminationDbContext> options)
        : base(options)
    {
    }
}