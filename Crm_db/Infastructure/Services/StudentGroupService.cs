using Dapper;
using Domain.Entities;

namespace Infastructure.Services;

public class StudentGroupService
{
    DataContext dataContext = new DataContext();
    public int AddStudentGroup(StudentGroups studentGroups)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"insert into StudentGroups (studentId,GroupId,Status) values (@studentId,@GroupId,@Status)";
            var res = con.Execute(cmd, studentGroups);
            return res;
        }
    }
    public List<StudentGroups> GetAllStudentGroups()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from studentGroups";
            var res = con.Query<StudentGroups>(cmd).ToList();
            return res;
        }
    }

    public Mentor GetStudentGroupById(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from studentGroups where mentorId = @Id";
            var res = con.QuerySingleOrDefault<Mentor>(cmd, new { Id = Id });
            return res;
        }
    }
    public int UpdateStudentGroup(StudentGroups studentGroups)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"update studentGroups set StudentId = @StudentId , GroupId = @GroupId , Status = @Status where mentorId = @studentGroupId ";
            var res = con.Execute(cmd, studentGroups);
            return res;
        }
    }

    public int DeleteStudentGroup(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"delete from studentGroups where studentGroupId = @Id";
            var res = con.Execute(cmd, new { Id = Id });
            return res;
        }
    }

}
