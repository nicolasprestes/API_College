using College.Application.Domain.Enrollments;
using College.Infra.Database.Interfaces;
using College.Infra.Database.Repositories;

namespace College.Extensions
{
    public static class EnrollmentCollectionExtensions
    {
        public static void EnrollmentsServices(this IServiceCollection services)
        {
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<CreateEnrollment>();
            services.AddScoped<FindEnrollment>();
        }
    }
}
