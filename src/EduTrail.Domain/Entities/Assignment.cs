namespace EduTrail.Domain.Entities;

public class Assignment
{
    public Guid Id { get; set; }
    public Guid TrailModuleId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public int MaxPoints { get; set; }
    public bool NeedsSubmission { get; set; }
    public List<string> Tags { get; set; } = [];

    // Navigation properties
    public TrailModule TrailModule { get; set; } = null!;
    public ICollection<AssignmentContent> Contents { get; set; } = [];
    public ICollection<AssignmentSubmission> Submissions { get; set; } = [];
    public ICollection<StudentProgress> Progress { get; set; } = [];
}
