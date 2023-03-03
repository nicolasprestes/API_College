using College.Application.Entities;
using College.Infra.Database.Interfaces;
using College.Infra.HTTP.Dto;

namespace College.Application.Domain.Courses
{
    public class UpdateCourse
    {
        private readonly ICourseRepository courseRepository;

        public UpdateCourse (ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task<Course> Execute (string courseId, CourseDTO courseDto)
        {
            var course = await this.courseRepository.FindByIdAsync(courseId);

            var courseUpdated = new Course(
                    courseDto.Name ?? course.Name,
                    courseDto.StartsAt ?? course.StartsAt,
                    courseDto.EndsAt ?? course.EndsAt,
                    course.Id
                );

            await this.courseRepository.UpdateAsync(courseUpdated);

            return courseUpdated;
        }
    }
}
