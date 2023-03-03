using College.Application.Domain.Courses;
using College.Application.Domain.Students;
using College.Infra.Database.Interfaces;
using College.Infra.Database.Repositories;

namespace College.Extensions
{
    public static class StudentCollectionExtensions
    {
        public static void StudentsServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<CreateStudent>();
            services.AddScoped<FindStudent>();
            services.AddScoped<UpdateStudent>();
            services.AddScoped<DeleteStudent>();
        }
    }
}
