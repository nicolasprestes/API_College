using College.Application.Model;
using College.Infra.Database.Interfaces;

namespace College.Application.Domain.Students
{
    public class FindStudent
    {
        private readonly IStudentRepository studentRepository;

        public FindStudent (IStudentRepository studentRepository) {
            this.studentRepository = studentRepository;
        }
        public async Task<Student> FindById (string studentId) {
            if (studentId == null) {
                throw new Exception("Id inválido");
            }

            return await this.studentRepository.FindByIdAsync(studentId);
        }
    }
}