using College.Application.Model;
using College.Infra.Database.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Xml.Linq;

namespace College.Application.Domain.Students
{
    public class UpdateStudent
    {
        private readonly IStudentRepository studentRepository;

        public UpdateStudent(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<Student> Execute (string studentId, StudentDTO studentDTO)
        {
            var student = await this.studentRepository.FindByIdAsync(studentId);

            var studentUpdated = new Student(
                studentDTO.Name ?? student.Name,
                studentDTO.Age ?? student.Age,
                studentDTO.Email ?? student.Email,
                studentDTO.EnrolledIn ?? student.EnrolledIn,
                student.Id
            );

            await this.studentRepository.UpdateAsync(studentUpdated);

            return studentUpdated;
        }
    }
}
