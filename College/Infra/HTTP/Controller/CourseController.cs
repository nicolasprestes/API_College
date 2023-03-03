using College.Application.Domain.Courses;
using College.Infra.HTTP.Dto;
using Microsoft.AspNetCore.Mvc;

namespace College.Infra.HTTP.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CreateCourse createCourse;
        private readonly FindCourse findCourse;
        private readonly UpdateCourse updateCourse;
        private readonly DeleteCourse deleteCourse;

        public CourseController (CreateCourse createCourse, FindCourse findCourse, UpdateCourse updateCourse, DeleteCourse deleteCourse)
        {
            this.createCourse = createCourse;
            this.findCourse = findCourse;
            this.updateCourse = updateCourse;
            this.deleteCourse = deleteCourse;
        }

        [HttpPost]
        public async Task<ActionResult> Create ([FromBody] CourseDTO courseDTO)
        {
            var course = await createCourse.Execute(courseDTO);

            return course != null ? Created(nameof(Create), course) : BadRequest("Não foi possivel criar o curso.");
        }

        [HttpGet("courseId")]
        public async Task<ActionResult> Find (string courseId)
        {
            var course = await this.findCourse.FindById(courseId);

            return course != null ? Ok(course) : BadRequest("Não foi possvel encontrar esse curso.");
        }

        [HttpPut("{courseId}")]
        public async Task<ActionResult> Update(string courseId, [FromBody] CourseDTO courseDto)
        {
            var course = await this.updateCourse.Execute(courseId, courseDto);

            return course != null ? Ok(course) : BadRequest("Não foi possivel atualizar esse curso.");
        }

        [HttpDelete("{courseId}")]
        public async Task<ActionResult> Delete (string courseId)
        {
            var courseDeleted = await this.deleteCourse.Execute(courseId);

            return courseDeleted ? Ok() : BadRequest("Ocorreu um erro ao deletar o curso.");
        }
    }
}
