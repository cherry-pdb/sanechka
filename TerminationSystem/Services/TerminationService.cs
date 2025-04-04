using Microsoft.EntityFrameworkCore;
using TerminationSystem.Data;
using TerminationSystem.Models;

namespace TerminationSystem.Services;

public class TerminationService
{
    private readonly TerminationDbContext _context;

    public TerminationService(TerminationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TerminationInfo>> GetAllTerminationReasonsAsync()
    {
        var records = await _context.Terminations
            .OrderBy(t => t.TerminationDate)
            .ToListAsync();

        var result = records.Select((record, index) => new TerminationInfo
        {
            Id = index + 1,
            PersonId = record.PersonId,
            FullName = record.FullName,
            TerminationDate = record.TerminationDate
        }).ToList();

        return result;
    }
}