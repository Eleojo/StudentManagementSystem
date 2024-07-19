# Student Management API

This project is a Student Management API built with ASP.NET Core. It allows for the management of student records, including their contact information, academic information, and advisor information. The API supports creating, updating, and removing student records, as well as updating specific parts of the student information.

## Features

- Add a new student with detailed information.
- Update student information, including selective updates for contact, academic, and advisor information.
- Remove a student record.
- Retrieve student information by ID.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- AutoMapper
- SQL Server

## Project Structure

- `Controllers/`: Contains API controllers for handling HTTP requests.
- `Dtos/`: Contains Data Transfer Objects (DTOs) for student, contact, academic, and advisor information.
- `Services/`: Contains business logic for managing student records.
- `Data/`: Contains the DbContext and entity configurations.

## Getting Started

### Prerequisites

- .NET 6.0 SDK
- SQL Server
- Visual Studio 2022 (recommended)

### Setup

1. Clone the repository:

    ```sh
    git clone https://github.com/your-username/student-management-api.git
    cd student-management-api
    ```

2. Configure the connection string in `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "StudentDatabase": "Server=your_server_name;Database=StudentDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
    ```

3. Apply migrations to the database:

    ```sh
    dotnet ef database update
    ```

4. Run the application:

    ```sh
    dotnet run
    ```

### API Endpoints

#### Add a New Student

```http
POST /api/students
```

- Request Body:

    ```json
    {
      "firstName": "John",
      "lastName": "Doe",
      "dateOfBirth": "2000-01-01",
      "gender": "Male",
      "contactInfo": {
        "email": "john.doe@example.com",
        "phoneNumber": "1234567890",
        "address": "123 Main St"
      },
      "academicInfo": {
        "course": "Computer Science",
        "yearOfStudy": "Senior",
        "gpa": 3.8,
        "major": "CS",
        "minor": "Math",
        "enrollmentStatus": "Enrolled"
      },
      "advisorInfo": {
        "advisorFirstName": "Jane",
        "advisorLastName": "Smith"
      }
    }
    ```

#### Update Student Information

```http
PUT /api/students/{id}
```

- Request Body:

    ```json
    {
      "firstName": "John",
      "lastName": "Doe",
      "dateOfBirth": "2000-01-01",
      "gender": "Male",
      "contactInfo": {
        "email": "john.doe@example.com",
        "phoneNumber": "1234567890",
        "address": "123 Main St"
      },
      "academicInfo": {
        "course": "Computer Science",
        "yearOfStudy": "Senior",
        "gpa": 3.8,
        "major": "CS",
        "minor": "Math",
        "enrollmentStatus": "Enrolled"
      },
      "advisorInfo": {
        "advisorFirstName": "Jane",
        "advisorLastName": "Smith"
      }
    }
    ```

#### Remove a Student

```http
DELETE /api/students/{id}
```

### Example Request

#### Add Student

```sh
curl -X POST "https://localhost:5001/api/students" -H "accept: text/plain" -H "Content-Type: application/json" -d "{
  \"firstName\": \"John\",
  \"lastName\": \"Doe\",
  \"dateOfBirth\": \"2000-01-01\",
  \"gender\": \"Male\",
  \"contactInfo\": {
    \"email\": \"john.doe@example.com\",
    \"phoneNumber\": \"1234567890\",
    \"address\": \"123 Main St\"
  },
  \"academicInfo\": {
    \"course\": \"Computer Science\",
    \"yearOfStudy\": \"Senior\",
    \"gpa\": 3.8,
    \"major\": \"CS\",
    \"minor\": \"Math\",
    \"enrollmentStatus\": \"Enrolled\"
  },
  \"advisorInfo\": {
    \"advisorFirstName\": \"Jane\",
    \"advisorLastName\": \"Smith\"
  }
}"
```

## Contributing

1. Fork the repository.
2. Create a new feature branch.
3. Commit your changes.
4. Push the branch.
5. Create a new pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

```

Replace `"your-username"` with your actual GitHub username and adjust any other details as necessary. This README provides a comprehensive overview of your project, setup instructions, and API endpoint usage.
