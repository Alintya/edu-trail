namespace EduTrail.Domain.Entities;

public class StudentProgress
{
    public Guid StudentId { get; set; }
    public Guid AssignmentId { get; set; }
    public DateTime? CompletedAt { get; set; }

    // Navigation properties
    public Student Student { get; set; } = null!;
    public Assignment Assignment { get; set; } = null!;

    public bool IsCompleted => CompletedAt.HasValue;
}
