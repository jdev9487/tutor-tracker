namespace JDev.Tuteee.ApiClient.DTOs;

public class TuteeDto
{
    public int? TuteeId { get; set; }
    public required string FirstName { get; set; } = default!;
    public required string LastName { get; set; } = default!;
    public required string EmailAddress { get; set; } = default!;
    public required int ClientId { get; set; }
    public IEnumerable<LessonDto>? Lessons { get; set; } = [];
    public IEnumerable<int>? RateIds { get; set; } = [];
}