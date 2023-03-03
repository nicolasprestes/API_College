using College.Application.Domain.Courses;
using College.Application.Domain.Students;
using College.Infra.Database.Interfaces;
using College.Infra.Database.Repositories;

namespace College.Extensions
{
    public static class CourseCollectionExtensions
    {
        public static void CoursesServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<CreateCourse>();
            services.AddScoped<FindCourse>();
            services.AddScoped<UpdateCourse>();
            services.AddScoped<DeleteCourse>();
        }
    }
}
