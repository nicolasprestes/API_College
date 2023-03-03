namespace College.Application.Entities
{
    public class Course
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public DateTime StartsAt { get; private set; }
        public DateTime EndsAt { get; private set; }

        public Course (string name, DateTime? startsAt = null, DateTime? endsAt = null, string? id = null)
        {
            Id = id ?? Guid.NewGuid().ToString();
            Name = name;
            StartsAt = startsAt ?? DateTime.Today;
            EndsAt = endsAt ?? this.StartsAt.AddDays(30);
        }
    }
}
