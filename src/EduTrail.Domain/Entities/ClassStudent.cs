namespace EduTrail.Domain.Entities;

public class ClassStudent
{
    public Guid ClassId { get; set; }
    public Guid StudentId { get; set; }
    public DateTime JoinedAt { get; set; }

    // Navigation properties
    public Class Class { get; set; } = null!;
    public Student Student { get; set; } = null!;
}
