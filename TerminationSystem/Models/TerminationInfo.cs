namespace TerminationSystem.Models;

public class TerminationInfo
{
    public int Id { get; set; }              
    public int PersonId { get; set; } 
    public string FullName { get; set; } = null!;
    public DateTime TerminationDate { get; set; }
}