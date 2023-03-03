using College.Application.Entities;
using College.Infra.Database.Interfaces;
using College.Infra.HTTP.Dto;

namespace College.Application.Domain.Enrollments
{
    public class CreateEnrollment
    {
        private readonly IEnrollmentRepository enrollmentRepository;

        public CreateEnrollment(IEnrollmentRepository enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }
        public async Task<Enrollment> Execute (EnrollmentDTO enrollmentDTO)
        {
            var enrollment = new Enrollment(
                    enrollmentDTO.StudentId,
                    enrollmentDTO.CourseId,
                    enrollmentDTO.EnrollmentIn,
                    enrollmentDTO.Status
                );

            await this.enrollmentRepository.CreateAsync(enrollment);

            return enrollment;
        }
    }
}
