using Dapper;
using Domain.Entites;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StudentService : IStudentService
{
    private readonly DataContext _context = new DataContext();

    public List<Student> GetAll()
    {
        using var connection = _context.GetConnection();

        const string cmd = $"select * from students";
        var students = connection.Query<Student>(cmd).ToList();

        return students;
    }

    public Student GetStudent(int id)
    {
        using var connection = _context.GetConnection();

        const string cmd = $"select * from students where id = @Id";
        var student = connection.QueryFirstOrDefault<Student>(cmd, new { Id = id });

        return student ?? new Student();
    }

    public int CreateStudent(Student student)
    {
        using var connection = _context.GetConnection();

        const string cmd = $@"insert into students(firstname, lastname, birthdate)
                    values (@FirstName, @LastName, @BirthDate)";

        var result = connection.Execute(cmd, student);

        return result;
    }

    public int UpdateStudent(Student student)
    {
        using var connection = _context.GetConnection();

        const string cmd = $@"update students set firstname = @FirstName, 
                     lastname = @LastName, birthdate = @BirthDate 
                     where id = @Id";

        var result = connection.Execute(cmd, student);

        return result;
    }

    public int DeleteStudent(int id)
    {
        using var connection = _context.GetConnection();

        const string cmd = "delete from students where id = @Id";

        var result = connection.Execute(cmd, new{Id = id});

        return result;
    }
}
