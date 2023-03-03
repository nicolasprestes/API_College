namespace College.Application.Entities
{
    public class Enrollment
    {
        public string Id { get; private set; }
        public bool Status { get; set; } = true;
        public string StudentId { get; private set; }
        public string CourseId { get; private set; }
        public DateTime EnrollmentIn { get; private set; }

        public Enrollment (string studentId, string courseId, DateTime? enrollmentIn = null, bool? status = null, string? id = null)
        {
            this.Id = id ?? Guid.NewGuid().ToString();
            this.Status = status ?? this.Status;
            this.StudentId = studentId;
            this.CourseId = courseId;
            this.EnrollmentIn = enrollmentIn ?? DateTime.Today;
        }
    }
}
