using College.Application.Entities;
using College.Infra.Database.Interfaces;
using College.Infra.HTTP.Dto;

namespace College.Application.Domain.Courses
{
    public class CreateCourse
    {
        private readonly ICourseRepository courseRepository;

        public CreateCourse(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public async Task<Course> Execute (CourseDTO courseDTO)
        {
            var course = new Course(courseDTO.Name, courseDTO.StartsAt, courseDTO.EndsAt);

            await this.courseRepository.CreateAsync(course);

            return course;
        }
    }
}
