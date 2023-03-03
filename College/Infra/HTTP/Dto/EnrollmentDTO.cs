namespace College.Infra.HTTP.Dto
{
    public class EnrollmentDTO
    {
        public bool? Status { get; set; }
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public DateTime? EnrollmentIn { get; set; }
    }
}
