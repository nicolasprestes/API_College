# API_College

## Solução de negócio
A API College é uma solução de negócio desenvolvida em C# e utiliza o framework Dapper para manipulação do banco de dados. O objetivo da API é permitir a inserção de alunos e cursos, possibilitando a matrícula de um aluno para cada curso criado.

## Como usar
Para utilizar a API_College, siga os seguintes passos:

1. Clone ou faça o download do repositório.
2. Abra o projeto em sua IDE de preferência.
3. Configure a conexão com o banco de dados em "appsettings.json".
4. Execute o script "database.sql" para criar o banco de dados e as tabelas necessárias.
5. Compile e execute a aplicação.

## Endpoints
A API_College possui os seguintes endpoints:

### Course
- POST /api/v1/course
- GET /api/v1/course/{courseId}
- PUT /api/v1/course/{courseId}
- DELETE /api/v1/course/{courseId}

### Enrollment
- GET /api/v1/enrollment/student/{studentId}
- POST /api/v1/enrollment
- Student
- POST /api/v1/student
- GET /api/v1/student/{id}
- PUT /api/v1/student/{id}
- DELETE /api/v1/student/{id}
