namespace College.Application.Model
{
    public class Student
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime EnrolledIn { get; set; } = DateTime.Today;

        // construtor que inicializa as propriedades com valores opcionais
        public Student(string name, int age, string email, DateTime? enrolledIn = null, string id = null)
        {
            this.Id = id ?? this.Id;
            this.Name = name;
            this.Age = age;
            this.Email = email;
            this.EnrolledIn = enrolledIn ?? this.EnrolledIn;
        }
    }
}
