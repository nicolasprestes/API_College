
using College.Application.Model;
using College.Infra.Database.Interfaces;

namespace College.Application.Domain.Students
{
    public class CreateStudent
    {
        private readonly IStudentRepository studentRepository;

        public CreateStudent(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<Student> Execute(StudentDTO studentDTO)
        {
            var studentAlreadyExist = await this.studentRepository.FindByEmailAsync(studentDTO.Email);
            if (studentAlreadyExist != null)
            {
                throw new Exception($"Já existe um estudante com o e-mail {studentDTO.Email}");
            }

            var student = new Student(
                studentDTO.Name,
                studentDTO.Age.Value,
                studentDTO.Email,
                studentDTO.EnrolledIn
            );

            if (await this.studentRepository.CreateAsync(student))
            {
                return student;
            }

            return null;
        }
    }
}