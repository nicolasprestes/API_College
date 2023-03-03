using College.Application.Model;

namespace College.Infra.Database.Interfaces
{
    public interface IReadRepositories<T>
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(string id);
    }

    public interface IWriteRepositories<T>
    {
        Task<bool> CreateAsync(T data);
        Task<bool> UpdateAsync(T data);
        Task<bool> DeleteAsync(string id);
    }
}
