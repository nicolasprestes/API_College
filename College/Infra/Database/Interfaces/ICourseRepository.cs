using College.Application.Entities;
using College.Application.Model;

namespace College.Infra.Database.Interfaces
{
    public interface ICourseRepository : IReadRepositories<Course>, IWriteRepositories<Course> { }
}
