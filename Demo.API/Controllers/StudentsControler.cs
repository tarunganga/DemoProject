using Demo.DataModel;
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

        // Create Student
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student == null || student.Id != Guid.Empty)
            {
                return BadRequest();
            }

            var id = studentService.AddStudent(student);

            return StatusCode(201, new { id });

        }

        // Update Student
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            if (student == null || student.Id == Guid.Empty)
            {
                return BadRequest();
            }

            studentService.UpdateStudent(student);

            return NoContent();
        }


        // Update Student --  JSON Patch
    }
}
