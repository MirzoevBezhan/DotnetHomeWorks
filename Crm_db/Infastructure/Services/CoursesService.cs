using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infastructure.Services;

public class CoursesService
{
    DataContext dataContext = new DataContext();
    public int AddCourse(Course course)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"insert into courses (Title,Description,DurationWeeks) values (@Title,@Description,@DurationWeeks)";
            var res = con.Execute(cmd, course);
            return res;
        }
    }
    public List<Course> GetAllCourses()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from courses";
            var res = con.Query<Course>(cmd).ToList();
            return res;
        }
    }

    public Course GetCourseById(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from courses where courseId = @Id";
            var res = con.QuerySingleOrDefault<Course>(cmd, new { Id = Id });
            return res;
        }
    }
    public int UpdateCourses(Course course)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"update courses set Title = @Title , Description = @Description , DurationWeeks = @DurationWeeks where courseId = @courseId";
            var res = con.Execute(cmd, course);
            return res;
        }
    }

    public int DeleteCourseById(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"delete from courses where courseId = @Id";
            var res = con.Execute(cmd, new { Id = Id });
            return res;
        }
    }

    public List<CourseWithStudentsCount> GetStudentsPerCourse()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select c.title ,count(sg.studentId) from courses as c join groups g on c.courseId = g.courseId join StudentGroups sg on g.groupId = sg.groupId group by c.Title";
            var res = con.Query<CourseWithStudentsCount>(cmd).ToList();
            return res;
        }
    }
    
    public CourseWithStudentsCount GetMostPopularCourse()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select c.title ,count(sg.studentId) as studentsCount from courses as c join groups g on c.courseId = g.courseId join StudentGroups sg on g.groupId = sg.groupId group by c.Title order by count(sg.studentId) desc ";
            var res = con.QuerySingleOrDefault<CourseWithStudentsCount>(cmd);
            return res;
        }
    }
    public List<CourseWithStudentsCount> GetLeastPopularCourses()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select c.title ,count(sg.studentId) as studentsCount from courses as c join groups g on c.courseId = g.courseId join StudentGroups sg on g.groupId = sg.groupId group by c.Title order by count(sg.studentId) limit 3";
            var res = con.Query<CourseWithStudentsCount>(cmd).ToList();
            return res;
        }
    }
    public List<CourseWithStudentsCount> GetTopThreeCourses()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select c.title ,count(sg.studentId) as studentsCount from courses as c join groups g on c.courseId = g.courseId join StudentGroups sg on g.groupId = sg.groupId group by c.Title order by count(sg.studentId)desc limit 3";
            var res = con.Query<CourseWithStudentsCount>(cmd).ToList();
            return res;
        }
    }
}
