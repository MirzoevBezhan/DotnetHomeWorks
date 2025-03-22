using Dapper;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace WebApi.Controllers;

public class StudentGroupService : IStudentGroupService
{
    private readonly DataContext _context = new DataContext();

    public List<StudentGroup> GetAll()
    {
        using var connection = _context.GetConnection();
        var cmd = "select * from StudentsGroups";
        return connection.Query<StudentGroup>(cmd).ToList();
    }

    public StudentGroup GetStudentGroup(int studentId,int groupId)
    {
        using var connection = _context.GetConnection();
        var cmd = "select * from StudentsGroups where StudentId = @StudentId and GroupId = @GroupId ";
        return connection.QueryFirstOrDefault<StudentGroup>(cmd, new { StudentId = studentId, GroupId = groupId });
    }

    public int CreateStudentGroup(StudentGroup studentGroup)
    {
        using var connection = _context.GetConnection();
        var cmd = "insert into StudentsGroups (StudentId, GroupId) values (@StudentId, @GroupId) ";
        return connection.Execute(cmd, studentGroup);
    }

    public int UpdateStudentGroup(StudentGroup studentGroup)
    {
        using var connection = _context.GetConnection();
        var cmd = "update StudentsGroups set GroupId = @GroupId where StudentId = @StudentId";
        return connection.Execute(cmd, studentGroup);
    }

    public int DeleteStudentGroup(int id)
    {
        using var connection = _context.GetConnection();
        var cmd = " delete from StudentsGroups where StudentId = @StudentId ";
        return connection.Execute(cmd, new { StudentId = id });
    }
}