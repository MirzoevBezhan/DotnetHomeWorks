using System.Text.RegularExpressions;
using Dapper;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class GroupService : IGroupService
{
    private readonly DataContext _context = new DataContext();

    public List<Group> GetAll()
    {
        using var connection = _context.GetConnection();
        const string cmd = "select * from Groups";
        return connection.Query<Group>(cmd).ToList();
    }

    public Group GetGroup(int Id)
    {
      using var connection = _context.GetConnection();
      const string cmd = "select * from Groups where Id = @Id";
      return connection.QuerySingleOrDefault<Group>(cmd, new { Id = Id });
    }

    public int CreateGroup(Group group)
    {
       using var connection = _context.GetConnection();
       const string cmd = "insert into Groups (Name,Status,StudentId) values (@Name,@Status,@StudentId)";
       return connection.Execute(cmd, group);
    }

    public int UpdateGroup(Group group)
    {
        using var connection = _context.GetConnection();
        const string cmd = "update Groups set Name = @Name,Status = @Status, StudentId = @StudentId where Id = @Id";
        return connection.Execute(cmd, group);
    }

    public int DeleteGroup(int Id)
    {
        using var connection = _context.GetConnection();
        const string cmd = "delete from groups where Id = @Id";
        return connection.Execute(cmd, new { Id = Id });
    }
}