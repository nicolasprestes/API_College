using College.Application.Entities;
using College.Application.Model;

namespace College.Infra.Database.Interfaces
{
    public interface IEnrollmentRepository : IReadRepositories<Enrollment>, IWriteRepositories<Enrollment> {
        Task<IEnumerable<Enrollment>> FindByStudentId (string studentId);
    }
}
