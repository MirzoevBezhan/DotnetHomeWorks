using Domain.Entites;

namespace Infrastructure.Interfaces;

public interface IStudentGroupService
{
    List<StudentGroup> GetAll();
    StudentGroup GetStudentGroup(int studentId,int groupId);
    int CreateStudentGroup(StudentGroup studentGroup);
    int UpdateStudentGroup(StudentGroup studentGroup);
    int DeleteStudentGroup(int id);
}