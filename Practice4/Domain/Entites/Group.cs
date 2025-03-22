using Domain.Enums;

namespace Domain.Entites;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Status Status { get; set; }
    public int StudentId { get; set; }
}
