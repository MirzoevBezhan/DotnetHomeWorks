using System.Text.RegularExpressions;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    List<Group> GetAll();
    Group GetGroup(int id);
    int CreateGroup(Group group);
    int UpdateGroup(Group group );
    int DeleteGroup(int id);
}