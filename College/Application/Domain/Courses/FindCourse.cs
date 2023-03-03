using College.Application.Entities;
using College.Infra.Database.Interfaces;

namespace College.Application.Domain.Courses
{
    public class FindCourse
    {
        private readonly ICourseRepository courseRepository;

        public FindCourse(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task<Course> FindById (string courseId)
        {
            var course = await this.courseRepository.FindByIdAsync (courseId);

            return course;
        }
    }
}
