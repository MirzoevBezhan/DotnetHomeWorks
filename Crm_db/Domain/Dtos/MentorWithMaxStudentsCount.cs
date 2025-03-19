namespace Domain.Dtos;

public class MentorWithMaxStudentsCount
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DurationWeeks { get; set; }
    public int Count { get; set; }
}
