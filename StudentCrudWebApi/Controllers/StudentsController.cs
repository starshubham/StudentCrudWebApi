using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCrudWebApi.Models;
using StudentCrudWebApi.RepositoryLayer.Interfaces;

namespace StudentCrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRL _studentRL;

        public StudentsController(IStudentRL studentRL)
        {
            _studentRL = studentRL;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> Getstudents()
        {
            try
            {
                var students = await _studentRL.GetAllStudents();
                if (students != null)
                {
                    return Ok(new { isSuccess = true, message = " All students found Successfully", data = students });
                }
                else
                {
                    return NotFound(new { isSuccess = false, message = "No Students Found" });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new { Status = 401, isSuccess = false, message = e.InnerException.Message });
            }
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var student = await _studentRL.GetStudentById(id);

                if (student == null)
                {
                    return NotFound(new { isSuccess = false, message = $"Student with id {id} not Found" });
                }
                return student;
            }
            catch (Exception e)
            {
                return BadRequest(new { Status = 401, isSuccess = false, message = e.InnerException.Message });
            }
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = await _studentRL.UpdateStudent(id, student);

                if (result != null)
                {
                    return Ok(new { isSuccess = true, message = $"Student with id {id} Updated Successfully", data = result });
                }
                else
                {
                    return NotFound(new { isSuccess = false, message = $"No Student with id {id} Found" });
                }
            }
            catch (Exception e)
            {               
                return BadRequest(new { Status = 401, isSuccess = false, message = e.InnerException.Message });
            }
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            try
            {
                var createStudent = await _studentRL.CreateStudent(student);

                if(createStudent != null)
                {
                    return Ok(new { status = 201, isSuccess = true, message = " Student created successfully ", data = createStudent });
                }
                else
                {
                    return BadRequest(new { status = 404, isSuccess = false, message = "Unsuccessful! Failed to create student" });
                }
            }
            catch (Exception e)
            {

                return BadRequest(new { Status = 401, isSuccess = false, message = e.InnerException.Message });
            }
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _studentRL.GetStudentById(id);
                if (student != null)
                {
                    await _studentRL.DeleteStudent(id);
                    return Ok(new {isSuccess = false, message = $"Student with id {id} Deleted Successfully!"});
                }
                else
                {
                    return NotFound(new { isSuccess = false, message = $"No student with id {id} found!" });
                }
                
            }
            catch (Exception e)
            {

                return this.BadRequest(new { Status = 401, isSuccess = false, message = e.InnerException.Message });
            }
        }

        private bool StudentExists(int id)
        {
            return _studentRL.StudentExists(id);
        }
    }
}
