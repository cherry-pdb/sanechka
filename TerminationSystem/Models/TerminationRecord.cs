using System.ComponentModel.DataAnnotations;

namespace TerminationSystem.Models;

public class TerminationRecord
{
    [Key]
    public int PersonId { get; init; }
    public string FullName { get; init; } = null!;
    public DateTime TerminationDate { get; init; }
}