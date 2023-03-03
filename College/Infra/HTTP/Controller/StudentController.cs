using College.Application.Domain.Students;
using Microsoft.AspNetCore.Mvc;

namespace College.Infra.HTTP.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CreateStudent createStudent;
        private readonly FindStudent findStudent;
        private readonly UpdateStudent updateStudent;
        private readonly DeleteStudent deleteStudent;

        public StudentController(CreateStudent createStudent, FindStudent findStudent, UpdateStudent updateStudent, DeleteStudent deleteStudent)
        {
            this.createStudent = createStudent;
            this.findStudent = findStudent;
            this.updateStudent = updateStudent;
            this.deleteStudent = deleteStudent;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] StudentDTO studentDTO)
        {
            var student = await createStudent.Execute(studentDTO);

            return student != null ? Created(nameof(Create), student) : BadRequest("Não foi possivel criar o aluno");
        }

        [HttpGet("id")]
        public async Task<ActionResult> FindById(string id) {
            var student = await findStudent.FindById(id);

            return student != null ? Ok(student) : BadRequest("Não foi possivel encontrar");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent (string id, [FromBody] StudentDTO studentDTO)
        {
            var student = await updateStudent.Execute(id, studentDTO);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent (string id)
        {
            var student = await deleteStudent.Execute(id);

            return student ? Ok("Deletado com sucesso.") : BadRequest("Não foi possivel encontrar");
        }
    }
}
