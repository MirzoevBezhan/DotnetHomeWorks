using System.Data;
using Dapper;
using Infastructure;
using Infastructure.Services;
using Npgsql;

namespace Domain.Dtos;

public class StatisticsService
{
    DataContext dataContext = new DataContext();
    public int GetTotalStudentsCount()
    {
        using (var com = dataContext.GetConnection())
        {
            var cmd = @"select count(*) from students";
            var res = com.Execute(cmd);
            return res;
        }
    }
    public int GetTotalGroupsCount()
    {
        using (var com = dataContext.GetConnection())
        {
            var cmd = @"select count(*) from groups";
            var res = com.Execute(cmd);
            return res;
        }
    }
    
    public int GetTotalCoursesCount()
    {
        using (var com = dataContext.GetConnection())
        {
            var cmd = @"select count(*) from courses";
            var res = com.Execute(cmd);
            return res;
        }
    }
    
    public int GetTotalMentorsCount()
    {
        using (var com = dataContext.GetConnection())
        {
            var cmd = @"select count(*) from mentors";
            var res = com.Execute(cmd);
            return res;
        }
    }
    
    public List<DateTime> GetAllUniqueStartDates()
    {
        using (var com = dataContext.GetConnection())
        {
            var cmd = @"select distinct StartDate from groups";
            var res = com.Query<DateTime>(cmd).ToList();
            return res;
        }
    }    
}
