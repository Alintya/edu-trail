namespace EduTrail.Domain.Entities;

public class Student : UserProfile
{
    public string? StudentNumber { get; set; }
    public DateTime EnrollmentDate { get; set; }

    // Navigation properties
    public ICollection<ClassStudent> EnrolledClasses { get; set; } = [];
    public ICollection<AssignmentSubmission> Submissions { get; set; } = [];
    public ICollection<StudentProgress> Progress { get; set; } = [];

    public void AssignToClass(Guid classId)
    {
        EnrolledClasses.Add(new ClassStudent
        {
            ClassId = classId,
            JoinedAt = DateTime.UtcNow,
            StudentId = Id
        });
    }
}
