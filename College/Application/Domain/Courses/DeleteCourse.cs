using College.Infra.Database.Interfaces;

namespace College.Application.Domain.Courses
{
    public class DeleteCourse
    {
        private readonly ICourseRepository courseRepository;

        public DeleteCourse(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task<bool> Execute (string courseId)
        {
            return await this.courseRepository.DeleteAsync(courseId);
        }
    }
}
