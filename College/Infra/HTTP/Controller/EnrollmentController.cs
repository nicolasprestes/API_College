using College.Application.Domain.Enrollments;
using College.Infra.HTTP.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace College.Infra.HTTP.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly CreateEnrollment createEnrollment;
        private readonly FindEnrollment findEnrollment;

        public EnrollmentController(CreateEnrollment createEnrollment, FindEnrollment findEnrollment)
        {
            this.createEnrollment = createEnrollment;
            this.findEnrollment = findEnrollment;
        }

        [HttpGet("student/{stundentId}")]
        public async Task<ActionResult> FindStudentEnrollment (string stundentId)
        {
            var studentEnrollment = await this.findEnrollment.FindByIdStudent(stundentId);

            return studentEnrollment.Any() ? Ok(studentEnrollment) : NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Create(EnrollmentDTO enrollmentDTO)
        {
            var enrollment = await this.createEnrollment.Execute(enrollmentDTO);

            return enrollment != null ? Created(nameof(Create), enrollment) : BadRequest("Não foi possivel criar.");
        }
    }
}
