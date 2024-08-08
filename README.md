Great, let's tailor the README to reflect your project's structure and include details about using Identity Framework and JWT authentication.

---

# Library Management System

## Overview

This project is a **Library Management System** built using **.NET**, following the **Clean Architecture** and **CQRS pattern**. It adheres to **SOLID principles**, leveraging various technologies and design patterns to ensure maintainability, scalability, and robustness.

## Features

- **Clean Architecture**: Ensures separation of concerns and maintainability.
- **CQRS Pattern**: Segregates read and write operations to optimize performance and scalability.
- **SOLID Principles**: Promotes best practices in software development.
- **FluentValidation**: Provides a fluent interface for building strongly-typed validation rules.
- **Generic Repository and Unit of Work**: Simplifies data access and management.
- **Code First Approach**: Uses Entity Framework Core with code first migrations.
- **Identity Framework**: Manages user authentication and authorization.
- **JWT Authentication**: Secures API endpoints with JSON Web Tokens.
- **MS SQL Server**: Serves as the database management system.
- **Global Exception Handling**: Middleware.
- **InMemory Caching/Scrutor/Decorator Design Pattern for BookRepository**: InmemCaching.


## Technologies Used

- **.NET Core**
- **Entity Framework Core**
- **MS SQL Server**
- **FluentValidation**
- **AutoMapper**
- **MediatR**
- **ASP.NET Core Web API**
- **Identity Framework**
- **JWT Authentication**
-  **Serilog**
-  **Global Exception Handling**
-  **GOF DesignPatterns/InMemCache**



## Getting Started

### Prerequisites

- .NET SDK 6.0 or later
- SQL Server
- Visual Studio or any preferred IDE

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/UcanCallMeBlobFish/LibraryManagement.git
   ```
2. Navigate to the project directory:
   ```sh
   cd LibraryManagement
   ```
3. Restore the dependencies:
   ```sh
   dotnet restore
   ```
4. Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server_name;Database=your_db_name;Trusted_Connection=True;MultipleActiveResultSets=true"
   },
   "Jwt": {
     "Key": "your_secret_key",
     "Issuer": "your_issuer",
     "Audience": "your_audience",
     "DurationInMinutes": 60
   }
   ```
5. Apply migrations to the database:
   ```sh
   dotnet ef database update
   ```
6. Run the application:
   ```sh
   dotnet run
   ```

## Project Structure

```plaintext
src/
|-- Application/
|   |-- Interfaces/
|   |-- Features/
|   |-- Validators/
|
|-- Domain/
|   |-- Entities/
|   |-- ValueObjects/
|
|-- Infrastructure/
|   |-- Data/
|   |-- Repositories/
|   |-- Services/
|
|-- Presentation/
|   |-- Controllers/
|   |-- Models/
|   |-- Middleware/
|
|-- WebAPI/
|   |-- Program.cs
|   |-- Startup.cs
```

- **Application**: Contains the application logic and business rules.
- **Domain**: Contains the core entities and value objects.
- **Infrastructure**: Contains data access implementations, including repositories and services.
- **Presentation**: Contains the API controllers, middleware, and related models.
- **WebAPI**: Contains the entry point of the application.

## Usage

- **API Documentation**: You can access the API documentation at `https://localhost:{port}/swagger` once the application is running.
- **Authentication**: Use the `/api/auth/login` endpoint to authenticate and receive a JWT token.
- **Sample Endpoints**:
  - `GET /api/books` - Retrieves a list of books.
  - `POST /api/books` - Creates a new book entry.
  - `PUT /api/books/{id}` - Updates an existing book entry.
  - `DELETE /api/books/{id}` - Deletes a book entry.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue to discuss any changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Contact

For any inquiries or feedback, please contact:

- **Your Name**
- **Email**: !
- **GitHub**: [UcanCallMeBlobFish](https://github.com/UcanCallMeBlobFish)

---

Feel free to adjust any section to better fit your project's details or specific requirements.



admin@localhost.com
user@localhost.com
P@ssword1
