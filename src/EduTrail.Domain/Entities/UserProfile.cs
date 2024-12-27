namespace EduTrail.Domain.Entities;

public abstract class UserProfile
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}
