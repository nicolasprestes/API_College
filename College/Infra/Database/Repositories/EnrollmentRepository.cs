using College.Application.Entities;
using College.Infra.Database.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace College.Infra.Database.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public EnrollmentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("SqlConnection");
        }
        public Task<IEnumerable<Enrollment>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> FindByIdAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Enrollment>> FindByStudentId(string studentId)
        {
            string sql = @"SELECT StudentId, CourseId, EnrollmentIn, Status, Id FROM tb_enrollment WHERE StudentId = @StudentId;";

            using (var con = new SqlConnection(this.connectionString))

            return await con.QueryAsync<Enrollment>(sql, new { StudentId = studentId });
        }

        public async Task<bool> CreateAsync(Enrollment data)
        {
            string sql = @"INSERT INTO tb_enrollment (Id, Status, StudentId, CourseId, EnrollmentIn) 
                   VALUES (@Id, @Status, @StudentId, @CourseId, @EnrollmentIn);";

            using (var con = new SqlConnection(this.connectionString))

                return await con.ExecuteAsync(sql, data) > 0;
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Enrollment data)
        {
            throw new NotImplementedException();
        }
    }
}
