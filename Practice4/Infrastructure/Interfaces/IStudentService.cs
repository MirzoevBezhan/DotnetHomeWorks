using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    List<Student> GetAll();
    Student GetStudent(int id);
    int CreateStudent(Student student);
    int UpdateStudent(Student student);
    int DeleteStudent(int id);
}
