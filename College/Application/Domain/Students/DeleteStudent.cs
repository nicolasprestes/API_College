using College.Infra.Database.Interfaces;

namespace College.Application.Domain.Students
{
    public class DeleteStudent
    {
        private readonly IStudentRepository studentRepository;

        public DeleteStudent (IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<bool> Execute (string studentId)
        {
            return await this.studentRepository.DeleteAsync(studentId);
        }
    }
}
