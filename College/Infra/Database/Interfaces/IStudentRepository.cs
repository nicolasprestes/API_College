using College.Application.Model;

namespace College.Infra.Database.Interfaces
{
    public interface IStudentRepository : IReadRepositories<Student>, IWriteRepositories<Student>
    {
        Task<Student> FindByEmailAsync(string email);
    }
}
