USE [master]
GO
/****** Object:  Database [EMS]    Script Date: 2/5/2025 10:49:06 PM ******/
CREATE DATABASE [EMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EMS', FILENAME = N'D:\Sql\MSSQL16.MSSQLSERVER\MSSQL\DATA\EMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EMS_log', FILENAME = N'D:\Sql\MSSQL16.MSSQLSERVER\MSSQL\DATA\EMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [EMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EMS] SET RECOVERY FULL 
GO
ALTER DATABASE [EMS] SET  MULTI_USER 
GO
ALTER DATABASE [EMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EMS', N'ON'
GO
ALTER DATABASE [EMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [EMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EMS]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[DateOfJoining] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DepartmentID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (20, N'Application Dev')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (17, N'Backend')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (18, N'Frontend')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (16, N'HR')
INSERT [dbo].[Department] ([DepartmentID], [DepartmentName]) VALUES (19, N'QA')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (6, N'Ram', CAST(12500.00 AS Decimal(18, 2)), CAST(N'2025-02-05T00:00:00.000' AS DateTime), 0, 20)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (7, N'test', CAST(4455.00 AS Decimal(18, 2)), CAST(N'2025-02-10T00:00:00.000' AS DateTime), 0, 17)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (8, N'John Doe', CAST(12000.00 AS Decimal(18, 2)), CAST(N'2025-02-01T00:00:00.000' AS DateTime), 0, 20)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (9, N'Jane Smith', CAST(11000.00 AS Decimal(18, 2)), CAST(N'2025-02-02T00:00:00.000' AS DateTime), 0, 17)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (10, N'Alice Johnson', CAST(10500.00 AS Decimal(18, 2)), CAST(N'2025-02-03T00:00:00.000' AS DateTime), 0, 18)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (11, N'Bob Brown', CAST(13000.00 AS Decimal(18, 2)), CAST(N'2025-02-04T00:00:00.000' AS DateTime), 0, 16)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (12, N'Charlie Davis', CAST(12500.00 AS Decimal(18, 2)), CAST(N'2025-02-05T00:00:00.000' AS DateTime), 0, 19)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (13, N'David Wilson', CAST(11800.00 AS Decimal(18, 2)), CAST(N'2025-02-06T00:00:00.000' AS DateTime), 0, 20)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (14, N'Emma Thomas', CAST(10750.00 AS Decimal(18, 2)), CAST(N'2025-02-07T00:00:00.000' AS DateTime), 0, 17)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (15, N'Frank White', CAST(9900.00 AS Decimal(18, 2)), CAST(N'2025-02-08T00:00:00.000' AS DateTime), 0, 18)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (16, N'Grace Harris', CAST(13500.00 AS Decimal(18, 2)), CAST(N'2025-02-09T00:00:00.000' AS DateTime), 0, 16)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Salary], [DateOfJoining], [IsDeleted], [DepartmentID]) VALUES (17, N'Henry Martin', CAST(12200.00 AS Decimal(18, 2)), CAST(N'2025-02-10T00:00:00.000' AS DateTime), 0, 19)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Departme__D949CC34BE81419C]    Script Date: 2/5/2025 10:49:07 PM ******/
ALTER TABLE [dbo].[Department] ADD UNIQUE NONCLUSTERED 
(
	[DepartmentName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddDepartment]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AddDepartment]
    @DepartmentName NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.Department (DepartmentName) VALUES (@DepartmentName);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AddEmployee]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_AddEmployee](
    @Name NVARCHAR(100),
    @DepartmentID INT,
    @Salary DECIMAL(18,2),
    @DateOfJoining DATETIME
)
As
BEGIN
    INSERT INTO Employee (Name, DepartmentID, Salary, DateOfJoining)
    VALUES (@Name, @DepartmentID, @Salary, @DateOfJoining);
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEmployee]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteEmployee]
    @EmployeeID INT
AS
BEGIN
    UPDATE dbo.Employee
    SET IsDeleted = 1
    WHERE EmployeeID = @EmployeeID;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDepartments]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllDepartments]
AS
BEGIN
    SELECT * FROM dbo.Department;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEmployees]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllEmployees]
AS
BEGIN
    SELECT 
        e.EmployeeID, 
        e.Name, 
        d.DepartmentName,
        e.Salary, 
        e.DateOfJoining,
		d.DepartmentID
    FROM dbo.Employee e
    INNER JOIN dbo.Department d ON e.DepartmentID = d.DepartmentID
    WHERE e.IsDeleted = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeById]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEmployeeById]
    @EmployeeID INT
AS
BEGIN
    SELECT 
        e.EmployeeID, 
        e.Name, 
        d.DepartmentName AS Department,  -- Join with Department table to get the department name
        e.Salary, 
        e.DateOfJoining
    FROM dbo.Employee e
    INNER JOIN dbo.Department d ON e.DepartmentID = d.DepartmentID  -- Join with Departments table
    WHERE e.EmployeeID = @EmployeeID AND e.IsDeleted = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 2/5/2025 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateEmployee]
    @EmployeeID INT,
    @Name NVARCHAR(100),
    @DepartmentID INT,  -- Changed from NVARCHAR to INT for DepartmentID
    @Salary DECIMAL(18,2),
    @DateOfJoining DATETIME
AS
BEGIN
    UPDATE dbo.Employee
    SET 
        Name = @Name,
        DepartmentID = @DepartmentID,  -- Updated to use DepartmentID (foreign key)
        Salary = @Salary,
        DateOfJoining = @DateOfJoining
    WHERE EmployeeID = @EmployeeID;
END;
GO
USE [master]
GO
ALTER DATABASE [EMS] SET  READ_WRITE 
GO
