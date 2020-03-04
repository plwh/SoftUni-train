CREATE DATABASE ReportService

USE ReportService

CREATE TABLE Departments
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL 
)

CREATE TABLE Categories
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender VARCHAR(1) CHECK (Gender IN ('M', 'F')),
	BirthDate DATETIME,
	Age INT,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT IDENTITY PRIMARY KEY,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Users
(
	Id INT IDENTITY PRIMARY KEY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Gender VARCHAR(1) CHECK (Gender IN ('M', 'F')),
	BirthDate DATETIME,
	Age INT,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Reports
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200),
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)