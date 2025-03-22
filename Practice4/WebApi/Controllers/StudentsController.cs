using Domain.Entites;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController
{
    private readonly StudentService studentService = new StudentService();

    [HttpGet]
    public List<Student> GetAll()
    {
        return studentService.GetAll();
    }

    [HttpGet("{id:int}")]
    public Student GetStudent(int id)
    {
        return studentService.GetStudent(id);
    }
    
    [HttpPost]
    public int CreateStudent(Student student)
    {
        var result = studentService.CreateStudent(student);
        return result;
    }
    
    [HttpPut]
    public int UpdateStudent(Student student)
    {
        return studentService.UpdateStudent(student);
    }
    
    
    [HttpDelete("{id:int}")]
    public int DeleteStudent(int id)
    {
        var result =studentService.DeleteStudent(id);
        return result;
    }


}
