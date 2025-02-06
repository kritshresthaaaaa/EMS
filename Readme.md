# Employee Management System

This is an MVC application built using .NET Core 8, Clean Architecture, and Dapper for database interactions. The frontend uses Razor views with Bootstrap for styling, and the backend uses SQL Server as the database.

## Prerequisites

Before setting up the project, ensure you have the following installed on your machine:

- .NET Core 8 SDK: [Download .NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server: [Download SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 (or later) or Visual Studio Code: [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- Git: [Download Git](https://git-scm.com/)

## Setup Instructions

### Clone the Repository:

git clone https://github.com/kritshresthaaaaa/EMS.git

### Restore Dependencies

Open the solution in Visual Studio or Visual Studio Code.
Restore the NuGet packages by running the following command:

dotnet restore

### Update Database Connection String

Open the appsettings.json file in the Employee Management System project.
Update the ConnectionStrings section with your SQL Server connection string:

"ConnectionStrings": {
"DefaultConnection": "Server=your-server;Database=EMS;Trusted_Connection=True;TrustServerCertificate=True;"
}

## Database Setup

### Create the Database:

Open SQL Server Management Studio (SSMS) or any SQL Server client.
Run the provided EMS.sql script to create the database, tables, seed data, and stored procedures.
Running the Application

## Start the Application

Navigate to the main folder and open Employee Management System.sln and press F5 or click the Run button.

### Access the Application:

Open your browser and navigate to:

http://localhost:5212 (or)
https://localhost:7065

The credientails are:

Email: testadmin@gmail.com
Password: Admin@123

## Technical Details

- Backend: .NET Core 8
- Frontend: Razor views with Bootstrap
- Database: SQL Server
- Database ORM: Dapper
- Validation
  All input validation is handled via Data Annotations and custom validation logic within the application.

### Stored Procedures

The application uses stored procedures for database operations like retrieving employee data, adding/editing employee records, etc.
