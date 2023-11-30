using System.Text.Json;
using Demo.Business;
using Demo.Contracts.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("students")]
    [ApiController]
    public class StudentsControler(IStudentService studentService) : ControllerBase
    {

        // Get All Students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var something = new JsonPatchDocument<StudentRequest>();
            something.Replace(x => x.Name, "New Name");
            something.Remove(x => x.Name);
            something.Add(x => x.Name, "New Name");


            string patches = JsonSerializer.Serialize(something.Operations);

            return Ok(studentService.GetAllStudents());
        }

        // Get Student by ID
        [HttpGet("{id}")]
        public IActionResult GetStudent(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(studentService.GetStudent(id));
        }

        // Delete Student
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            studentService.DeleteStudent(id);

            return NoContent();
        }

        // Update Student - Put
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Guid id, StudentRequest student)
        {
            if (student == null || id == Guid.Empty)
            {
                return BadRequest();
            }

            studentService.UpdateStudent(id, student);

            return NoContent();
        }


        // Update Student --  JSON Patch
        [HttpPatch("{id}")]
        public IActionResult UpdateStudent(Guid id, [FromBody]JsonPatchDocument<StudentRequest> patchDocument)
        {
            if (patchDocument == null || id == Guid.Empty)
            {
                return BadRequest();
            }

            var existingStudent = new StudentRequest();
            patchDocument.ApplyTo(existingStudent);

            studentService.UpdateStudent(id, existingStudent);

            return NoContent();
        }


        // Create Student
        [HttpPost]
        public IActionResult CreateStudent(StudentRequest student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            var id = studentService.AddStudent(student);

            return StatusCode(201, new { id });

        }
    }
}
