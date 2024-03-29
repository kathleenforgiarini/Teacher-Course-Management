USE [master]
GO
/****** Object:  Database [TeacherCourseDB]    Script Date: 21/02/2024 10:35:25 ******/
CREATE DATABASE [TeacherCourseDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TeacherCourseDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TeacherCourseDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TeacherCourseDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\TeacherCourseDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TeacherCourseDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TeacherCourseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TeacherCourseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TeacherCourseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TeacherCourseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TeacherCourseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TeacherCourseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TeacherCourseDB] SET  MULTI_USER 
GO
ALTER DATABASE [TeacherCourseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TeacherCourseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TeacherCourseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TeacherCourseDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TeacherCourseDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TeacherCourseDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TeacherCourseDB', N'ON'
GO
ALTER DATABASE [TeacherCourseDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [TeacherCourseDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TeacherCourseDB]
GO
/****** Object:  Table [dbo].[CourseAssignments]    Script Date: 21/02/2024 10:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignments](
	[EmployeeNumber] [int] NOT NULL,
	[CourseNumber] [varchar](7) NOT NULL,
	[AssignedDate] [date] NOT NULL,
	[GroupNumber] [int] NOT NULL,
 CONSTRAINT [pk_course_assign] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC,
	[CourseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 21/02/2024 10:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseNumber] [varchar](7) NOT NULL,
	[CourseTitle] [varchar](50) NOT NULL,
	[TotalHour] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 21/02/2024 10:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeNumber] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[JobTitle] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 21/02/2024 10:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupNumber] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21/02/2024 10:35:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserName] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CourseAssignments] ([EmployeeNumber], [CourseNumber], [AssignedDate], [GroupNumber]) VALUES (1234, N'COMP101', CAST(N'2024-02-21' AS Date), 7125)
INSERT [dbo].[CourseAssignments] ([EmployeeNumber], [CourseNumber], [AssignedDate], [GroupNumber]) VALUES (1234, N'COMP102', CAST(N'2024-02-21' AS Date), 7122)
INSERT [dbo].[CourseAssignments] ([EmployeeNumber], [CourseNumber], [AssignedDate], [GroupNumber]) VALUES (1234, N'COMP203', CAST(N'2024-02-21' AS Date), 7126)
INSERT [dbo].[CourseAssignments] ([EmployeeNumber], [CourseNumber], [AssignedDate], [GroupNumber]) VALUES (1235, N'COMP102', CAST(N'2024-02-22' AS Date), 7124)
INSERT [dbo].[CourseAssignments] ([EmployeeNumber], [CourseNumber], [AssignedDate], [GroupNumber]) VALUES (1235, N'COMP105', CAST(N'2024-02-22' AS Date), 7124)
INSERT [dbo].[CourseAssignments] ([EmployeeNumber], [CourseNumber], [AssignedDate], [GroupNumber]) VALUES (1235, N'COMP202', CAST(N'2024-02-07' AS Date), 7128)
GO
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [TotalHour]) VALUES (N'COMP101', N'Introduction to C# Programing', 75)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [TotalHour]) VALUES (N'COMP102', N'Advanced Programming in C#', 75)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [TotalHour]) VALUES (N'COMP103', N'Web Applications I', 90)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [TotalHour]) VALUES (N'COMP104', N'Web Applications II', 90)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [TotalHour]) VALUES (N'COMP105', N'Web Applications III', 90)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [TotalHour]) VALUES (N'COMP201', N'Python Programming I', 75)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [TotalHour]) VALUES (N'COMP202', N'Python Programming II', 75)
INSERT [dbo].[Courses] ([CourseNumber], [CourseTitle], [TotalHour]) VALUES (N'COMP203', N'Python Programming III', 90)
GO
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [JobTitle]) VALUES (1234, N'Mary', N'Brown', N'Teacher')
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [JobTitle]) VALUES (1235, N'Richard', N'Green', N'Teacher')
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [JobTitle]) VALUES (1236, N'Michael', N'Freitag', N'Teacher')
INSERT [dbo].[Employees] ([EmployeeNumber], [FirstName], [LastName], [JobTitle]) VALUES (4444, N'David', N'Cadieux', N'Program Coordinator')
GO
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7122, N'DEC Networking')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7123, N'DEC Programmation')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7124, N'AEC Programming')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7125, N'AEC Réseaux')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7126, N'DEC Networking')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7127, N'DEC Programmation')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7128, N'AEC Programming')
INSERT [dbo].[Groups] ([GroupNumber], [Description]) VALUES (7129, N'AEC Programmation')
GO
INSERT [dbo].[Users] ([UserName], [Password]) VALUES (1234, N'mary1234')
INSERT [dbo].[Users] ([UserName], [Password]) VALUES (1235, N'richard1235')
INSERT [dbo].[Users] ([UserName], [Password]) VALUES (1236, N'Michael1236')
INSERT [dbo].[Users] ([UserName], [Password]) VALUES (4444, N'david4444')
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD  CONSTRAINT [fk_course] FOREIGN KEY([CourseNumber])
REFERENCES [dbo].[Courses] ([CourseNumber])
GO
ALTER TABLE [dbo].[CourseAssignments] CHECK CONSTRAINT [fk_course]
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD  CONSTRAINT [fk_employee] FOREIGN KEY([EmployeeNumber])
REFERENCES [dbo].[Employees] ([EmployeeNumber])
GO
ALTER TABLE [dbo].[CourseAssignments] CHECK CONSTRAINT [fk_employee]
GO
ALTER TABLE [dbo].[CourseAssignments]  WITH CHECK ADD  CONSTRAINT [fk_group] FOREIGN KEY([GroupNumber])
REFERENCES [dbo].[Groups] ([GroupNumber])
GO
ALTER TABLE [dbo].[CourseAssignments] CHECK CONSTRAINT [fk_group]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_empNumber] FOREIGN KEY([EmployeeNumber])
REFERENCES [dbo].[Users] ([UserName])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_empNumber]
GO
USE [master]
GO
ALTER DATABASE [TeacherCourseDB] SET  READ_WRITE 
GO
