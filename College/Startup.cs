using College.Extensions;

namespace College
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            StudentCollectionExtensions.StudentsServices(services);
            CourseCollectionExtensions.CoursesServices(services);
            EnrollmentCollectionExtensions.EnrollmentsServices(services);
        }
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
