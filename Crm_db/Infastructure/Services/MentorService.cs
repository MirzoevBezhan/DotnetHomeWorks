using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infastructure.Services;

public class MentorService
{
    DataContext dataContext = new DataContext();
    public int AddMentor(Mentor mentor)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"insert into mentors (FullName,Email,Phone,Specialization) values (@FullName,@Email,@Phone,@Specialization)";
            var res = con.Execute(cmd, mentor);
            return res;
        }
    }
    public List<Mentor> GetAllMentors()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from mentors";
            var res = con.Query<Mentor>(cmd).ToList();
            return res;
        }
    }

    public Mentor GetMentorById(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from mentors where mentorId = @Id";
            var res = con.QuerySingleOrDefault<Mentor>(cmd, new { Id = Id });
            return res;
        }
    }
    public int UpdateMentor(Mentor mentor)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"update mentors set FullName = @FullName , Email = @Email , Phone = @Phone , Specialization = @Specialization where mentorId = @studentId ";
            var res = con.Execute(cmd, mentor);
            return res;
        }
    }

    public int DeleteMentor(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"delete from mentors where mentorId = @Id";
            var res = con.Execute(cmd, new { Id = Id });
            return res;
        }
    }
    public MentorWithMaxStudentsCount GetMentorWithMostStudents()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select  m.*, count(sg.studentId) from mentors as m join groups as g on g.mentorId = m.mentorId join studentGroups as sg on sg.groupId = g.GroupId group by (m.mentorId)order by count(sg.studentId) desc ";
            var res = con.QuerySingleOrDefault<MentorWithMaxStudentsCount>(cmd);
            return res;
        }
    }

    public List<Mentor> GetMentorsWithMultipleCourses()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select m.* from mentors as m join groups as g on g.mentorId = m.mentorId group by m.mentorId having count (g.courseid)>1";
            var res = con.Query<Mentor>(cmd).ToList();
            return res;
        }
    }
}
