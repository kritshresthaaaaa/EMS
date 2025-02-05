# Employee Management System (EMS)

This is an MVC application built using .NET Core 8, Clean Architecture, and Dapper for database interactions. The frontend uses Razor views with Bootstrap for styling, and the backend uses SQL Server as the database.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Technical Details](#technical-details)
- [Validation](#validation)
- [Stored Procedures](#stored-procedures)
- [License](#license)
- [Contact](#contact)

## Prerequisites

Before setting up the project, ensure you have the following installed on your machine:

- .NET Core 8 SDK: [Download .NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server: [Download SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 (or later) or Visual Studio Code: [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- Git: [Download Git](https://git-scm.com/)

## Setup Instructions

### Clone the Repository:

```bash
git clone https://github.com/kritshresthaaaaa/EMS.git
Restore Dependencies:
Open the solution in Visual Studio or Visual Studio Code.
Restore the NuGet packages by running the following command:
bash
Copy
Edit
dotnet restore
Update Database Connection String:
Open the appsettings.json file in the Employee Management System project.
Update the ConnectionStrings section with your SQL Server connection string:
json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=your-server;Database=EMS;Trusted_Connection=True;TrustServerCertificate=True;"
}
Database Setup
Create the Database:
Open SQL Server Management Studio (SSMS) or any SQL Server client.
Run the provided EMS.sql script to create the database, tables, seed data, and stored procedures.
Running the Application
Start the Application:
In Visual Studio, press F5 or click the Run button.
Alternatively, use the command line:
bash
Copy
Edit
dotnet run --project Employee_Management_System
Access the Application:
Open your browser and navigate to:

http://localhost:5212 (or)
https://localhost:7065
Project Structure
The project follows Clean Architecture principles and is organized as follows:

bash
Copy
Edit
Employee_Management_System/
├── Employee_Management_System.Application/  # Application layer (DTOs, Interfaces, Services)
├── Employee_Management_System.Domain/      # Domain layer (Entities, Enums, Exceptions)
├── Employee_Management_System.Infrastructure/ # Infrastructure layer (Repositories, Database Context)
├── Employee_Management_System/             # Presentation layer (Controllers, Views, Program.cs)
├── appsettings.json                        # Configuration file
├── Program.cs                              # Entry point of the application
└── README.md                               # Project documentation
Technical Details
Backend: .NET Core 8
Frontend: Razor views with Bootstrap
Database: SQL Server
Database Interaction: Dapper
Validation
All input validation is handled via Data Annotations and custom validation logic within the application.

Stored Procedures
The application uses stored procedures for database operations like retrieving employee data, adding/editing employee records, etc.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any questions or issues, please contact:

Your Name: shresthakrit1010@gmail.com
bash
Copy
Edit

### Fixes made:
- Proper indentation and formatting for sections like "Restore Dependencies", "Database Setup", and others.
- Added missing sections that were concatenated incorrectly in the original draft.
```
