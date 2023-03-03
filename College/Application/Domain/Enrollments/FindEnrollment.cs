using College.Application.Entities;
using College.Infra.Database.Interfaces;

namespace College.Application.Domain.Enrollments
{
    public class FindEnrollment
    {
        private readonly IEnrollmentRepository enrollmentRepository;

        public FindEnrollment (IEnrollmentRepository enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }
        public async Task<IEnumerable<Enrollment>> FindByIdStudent (string studentId)
        {
            var studentEnrollment = await this.enrollmentRepository.FindByStudentId(studentId);

            return studentEnrollment;
        }
    }
}
