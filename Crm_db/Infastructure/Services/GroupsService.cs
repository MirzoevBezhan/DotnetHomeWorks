using System.Text.RegularExpressions;
using Dapper;

namespace Infastructure.Services;

public class GroupsService
{
     DataContext dataContext = new DataContext();
    public int AddGroup(Group group)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"insert into groups (GroupName,CourseId,MentorId,StartDate,EndDate) values (@GroupName,@CourseId,@MentorId,@StartDate,@EndDate)";
            var res = con.Execute(cmd, group);
            return res;
        }
    }
    public List<Group> GetAllGroups()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from groups";
            var res = con.Query<Group>(cmd).ToList();
            return res;
        }
    }

    public Group GetGroupById(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from groups where groupId = @Id";
            var res = con.QuerySingleOrDefault<Group>(cmd, new { Id = Id });
            return res;
        }
    }
    public int UpdateGroup(Group group)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"update groups set GroupName = @GroupName , CourseId = @CourseId , MentorId = @MentorId , StartDate = @StartDate, EndDate = @EndDate where groupId = @groupId ";
            var res = con.Execute(cmd, group);
            return res;
        }
    }

    public int DeleteGroup(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"delete from groups where groupId = @Id";
            var res = con.Execute(cmd, new { Id = Id });
            return res;
        }
    }

}
