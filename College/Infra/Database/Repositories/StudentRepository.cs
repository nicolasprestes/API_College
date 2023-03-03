using College.Application.Model;
using College.Infra.Database.Interfaces;
using Dapper;
using System.Data.SqlClient;
using System.Text.Json;

namespace College.Infra.Database.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public bool JsonConvert { get; private set; }

        public StudentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("SqlConnection");
        }
        public async Task<IEnumerable<Student>> FindAllAsync()
        {
            string sql = @"SELECT * FROM tb_students";
            using (var con = new SqlConnection(this.connectionString))
            
            return await con.QueryAsync<Student>(sql);
        }

        public async Task<Student> FindByEmailAsync(string email)
        {
            string sql = @"SELECT * FROM tb_students WHERE Email = @Email";
            using (var con = new SqlConnection(this.connectionString))

            return await con.QueryFirstOrDefaultAsync<Student>(sql, new { Email = email });
        }

        public async Task<Student> FindByIdAsync(string id)
        {
            string sql = @"SELECT Name, Age, Email, EnrolledIn, Id FROM tb_students WHERE Id = @Id;";
            using (var con = new SqlConnection(this.connectionString))

            return await con.QueryFirstOrDefaultAsync<Student>(sql, new { Id = id.ToString() });
        }

        public async Task<bool> CreateAsync(Student data)
        {
            string sql = @"INSERT INTO tb_students (Id, Name, Age, Email, EnrolledIn) VALUES (@Id, @Name, @Age, @Email, @EnrolledIn);";

            using (var con = new SqlConnection(this.connectionString))

            return await con.ExecuteAsync(sql, data) > 0;
        }

        public async Task<bool> UpdateAsync(Student data)
        {
            string sql = @"UPDATE tb_students SET Name = @Name, Age = @Age, Email = @Email, EnrolledIn = @EnrolledIn WHERE Id = @Id";

            using (var con = new SqlConnection(this.connectionString))

            return await con.ExecuteAsync(sql, data) > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            string sql = @"DELETE FROM tb_students WHERE Id = @Id";

            using (var con = new SqlConnection(this.connectionString))

            return await con.ExecuteAsync(sql, new { Id = id }) > 0;
        }
    }
}
