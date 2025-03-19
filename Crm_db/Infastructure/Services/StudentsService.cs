using Dapper;
using Domain.Entities;
using Npgsql;

namespace Infastructure.Services;

public class StudentsService
{
    DataContext dataContext = new DataContext();
    public int AddStudent(Student student)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"insert into students (FullName,Email,Phone,EnrollmentDate) values (@FullName,@Email,@Phone,@EnrollmentDate)";
            var res = con.Execute(cmd, student);
            return res;
        }
    }
    public List<Student> GetAllStudents()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from students";
            var res = con.Query<Student>(cmd).ToList();
            return res;
        }
    }

    public Student GetStudentById(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from students where studentId = @Id";
            var res = con.QuerySingleOrDefault<Student>(cmd, new { Id = Id });
            return res;
        }
    }
    public int UpdateStudent(Student student)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"update students set FullName = @FullName , Email = @Email , Phone = @Phone , EnrollmentDate = @EnrollmentDate where studentId = @studentId ";
            var res = con.Execute(cmd, student);
            return res;
        }
    }

    public int DeleteStudent(int Id)
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"delete from students where studentId = @Id";
            var res = con.Execute(cmd, new { Id = Id });
            return res;
        }
    }
    public List<StudentGroups> GetStudentWithGroups()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from studentGroup";
            var res = con.Query<StudentGroups>(cmd).ToList();
            return res;
        }
    }
    
    public List<Student> GetStudentWithoutGroups()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select s.* from students as s left join studentGroups sg on s.studentId = sg.studentId where sg.studentId is null";
            var res = con.Query<Student>(cmd).ToList();
            return res;
        }
    }
    
    public List<Student> GetDroppedOutStudents()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from students where studentid not in(select studentId from studentGroups where status = 'Отчислен')";
            var res = con.Query<Student>(cmd).ToList();
            return res;
        }
    }
    
    public List<Student> GetGraduatedStudents()
    {
        using (var con = dataContext.GetConnection())
        {
            var cmd = @"select * from students where studentid not in(select studentId from studentGroups where status = 'Завершил')";
            var res = con.Query<Student>(cmd).ToList();
            return res;
        }
    }
    
}
