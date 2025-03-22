using Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class StudentsGroupsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController
    {
        private readonly StudentGroupService StudentGroupService = new();

        [HttpGet]
        public List<StudentGroup> GetAll()
        {
            return StudentGroupService.GetAll();
        }

        [HttpGet("{id:int}")]
        public StudentGroup GetStudentGroup(int studentId, int groupId)
        {
            return StudentGroupService.GetStudentGroup(studentId, groupId);
        }

        [HttpPost]
        public int CreateStudentGroup(StudentGroup studentGroup)
        {
            var result = StudentGroupService.CreateStudentGroup(studentGroup);
            return result;
        }

        [HttpPut]
        public int UpdateStudentGroup(StudentGroup studentGroup)
        {
            return StudentGroupService.UpdateStudentGroup(studentGroup);
        }


        [HttpDelete("{id:int}")]
        public int DeleteStudentGroup(int id)
        {
            var result = StudentGroupService.DeleteStudentGroup(id);
            return result;
        }


    }
}