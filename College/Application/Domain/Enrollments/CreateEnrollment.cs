using College.Application.Entities;
using College.Infra.Database.Interfaces;
using College.Infra.HTTP.Dto;

namespace College.Application.Domain.Enrollments
{
    public class CreateEnrollment
    {
        private readonly IEnrollmentRepository enrollmentRepository;
        private readonly ICourseRepository courseRepository;

        public CreateEnrollment(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
            this.courseRepository = courseRepository;
        }
        public async Task<Enrollment> Execute(EnrollmentDTO enrollmentDTO)
        {
            var courseExist = await this.courseRepository.FindByIdAsync(enrollmentDTO.CourseId);
            if (courseExist == null)
            {
                throw new Exception("Curso não encontrado");
            }

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
