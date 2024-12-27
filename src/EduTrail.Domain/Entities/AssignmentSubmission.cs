namespace EduTrail.Domain.Entities;

public class AssignmentSubmission
{
    public Guid Id { get; set; }
    public Guid AssignmentId { get; set; }
    public string StudentId { get; set; } = string.Empty;
    public string SubmissionUrl { get; set; } = string.Empty;
    public DateTime SubmittedAt { get; set; }
    public int? Score { get; set; }
    public string? Feedback { get; set; }

    // Navigation properties
    public Assignment Assignment { get; set; } = null!;
    public Student Student { get; set; } = null!;
}
