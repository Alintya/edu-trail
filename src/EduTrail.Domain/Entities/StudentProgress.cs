namespace EduTrail.Domain.Entities;

public class StudentProgress
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleContentId { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }

    // Navigation properties
    public Student Student { get; set; } = null!;
    public ModuleContent ModuleContent { get; set; } = null!;
}
