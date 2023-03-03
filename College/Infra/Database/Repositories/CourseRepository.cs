using College.Application.Entities;
using College.Application.Model;
using College.Infra.Database.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace College.Infra.Database.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public CourseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("SqlConnection");
        }

        public async Task<IEnumerable<Course>> FindAllAsync()
        {
            string sql = @"SELECT Name, StartsAt, EndsAt, Id FROM tb_courses;";
            using (var con = new SqlConnection(this.connectionString))

            return await con.QueryAsync<Course>(sql);
        }

        public async Task<Course> FindByIdAsync(string id)
        {
            string sql = @"SELECT Name, StartsAt, EndsAt, Id FROM tb_courses WHERE Id = @Id;";
            using (var con = new SqlConnection(this.connectionString))

            return await con.QueryFirstOrDefaultAsync<Course>(sql, new { Id = id });
        }

        public async Task<bool> UpdateAsync(Course data)
        {
            string sql = @"UPDATE tb_courses SET Name = @Name, StartsAt = @StartsAt, EndsAt = @EndsAt WHERE Id = @Id";

            using (var con = new SqlConnection(this.connectionString))

            return await con.ExecuteAsync(sql, data) > 0;
        }

        public async Task<bool> CreateAsync(Course data)
        {
            string sql = @"INSERT INTO tb_courses (Id, Name, StartsAt, EndsAt) VALUES (@Id, @Name, @StartsAt, @EndsAt);";

            using (var con = new SqlConnection(this.connectionString))

            return await con.ExecuteAsync(sql, data) > 0;
        }

        public async Task<bool> DeleteAsync(string courseId)
        {
            string sql = @"BEGIN TRANSACTION
                            DELETE FROM tb_enrollment WHERE CourseId = @Id;
                            DELETE FROM tb_courses WHERE Id = @Id;
                        COMMIT;";

            using (var con = new SqlConnection(this.connectionString))

            return await con.ExecuteAsync(sql, new { Id = courseId }) > 0;
        }
    }
}
