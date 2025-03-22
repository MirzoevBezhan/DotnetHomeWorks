using System.Text.RegularExpressions;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController
{
    private readonly GroupService groupService = new GroupService();

    [HttpGet]
    public List<Group> GetAllGroups()
    {
        return groupService.GetAll();
    }
    
    [HttpGet("{id:int}")]
    public Group GetGroupById(int id)
    {
        return groupService.GetGroup(id);
    }

    [HttpPost]
    public int CreateGroup(Group group)
    {
        var res=groupService.CreateGroup(group);
        return res;
    }

    [HttpPut]
    public int UpdateGroup(Group group)
    {
        return groupService.UpdateGroup(group);
    }

    [HttpDelete("{id:int}")]
    public int DeleteGroup(int id)
    {
        return groupService.DeleteGroup(id);
    }
}