Employee Management System
This is an MVC application built using .NET Core 8, Clean Architecture, and Dapper for database interactions. The frontend uses Razor views with Bootstrap for styling, and the backend uses SQL Server as the database.

Table of Contents
Prerequisites

Setup Instructions

Database Setup

Running the Application

Project Structure

Technical Details

Validation

Stored Procedures

Prerequisites
Before setting up the project, ensure you have the following installed on your machine:

.NET Core 8 SDK: Download .NET Core 8 SDK

SQL Server: Download SQL Server

Visual Studio 2022 (or later) or Visual Studio Code: Download Visual Studio

Git: Download Git

Setup Instructions
Clone the Repository:

bash

git clone https://github.com/kritshresthaaaaa/EMS.git
Restore Dependencies:

Open the solution in Visual Studio or Visual Studio Code.

Restore the NuGet packages by running:

bash

dotnet restore
Update Database Connection String:

Open the appsettings.json file in the Employee Management System project.

Update the ConnectionStrings section with your SQL Server connection string:

json

"ConnectionStrings": {
"DefaultConnection": "Server=your-server;Database=EMS;Trusted_Connection=True;TrustServerCertificate=True;"
}
Database Setup
Create the Database:

Open SQL Server Management Studio (SSMS) or any SQL Server client.

Run the provided EMS.sql script to create the database,tables,seed and stored procedures

Start the Application:

In Visual Studio, press F5 or click the Run button.

Alternatively, use the command line:

bash

dotnet run --project Employee_Management_System
Access the Application:

Open your browser and navigate to http://localhost:5212 (or https://localhost:7065).

Project Structure
The project follows Clean Architecture principles and is organized as follows:

Employee_Management_System/
├── Employee_Management_System.Application/ # Application layer (DTOs, Interfaces, Services)
├── Employee_Management_System.Domain/ # Domain layer (Entities, Enums, Exceptions)
├── Employee_Management_System.Infrastructure/ # Infrastructure layer (Repositories, Database Context)
├── Employee_Management_System/ # Presentation layer (Controllers, Views, Program.cs)
├── appsettings.json # Configuration file
├── Program.cs # Entry point of the application
└── README.md # Project documentation

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any questions or issues, please contact:

Your Name: your.email@example.com

GitHub: your-github-profile
