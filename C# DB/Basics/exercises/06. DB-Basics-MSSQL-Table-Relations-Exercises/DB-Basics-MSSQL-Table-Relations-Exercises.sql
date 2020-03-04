--Problem 1. One-To-One Relationship

CREATE DATABASE Test

USE Test

CREATE TABLE Persons
(
	PersonID INT IDENTITY,
	FirstName VARCHAR(10) NOT NULL,
	Salary DECIMAL(7, 2) NOT NULL,
	PassportID INT NOT NULL
)

ALTER TABLE Persons
ADD CONSTRAINT PK_Persons PRIMARY KEY (PersonID)

CREATE TABLE Passports
(
	PassportID INT IDENTITY(101, 1) PRIMARY KEY,
	PassporNumber VARCHAR(10) NOT NULL
)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports FOREIGN KEY (PassportID)
REFERENCES Passports(PassportID)

INSERT INTO Passports
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--Problem 2. One-To-Many Relationship

CREATE TABLE Models
(
	ModelID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(10) NOT NULL,
	ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(10) NOT NULL,
	EstablishedOn DATE NOT NULL
)

ALTER TABLE Models
ADD CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)

INSERT INTO Manufacturers
VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models
VALUES
('X1', 1),
('i6', 1),
('Models S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

--Problem 3. Many-To-Many Relationship

CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(10) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(10) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudentsExams_Students FOREIGN KEY(StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY(ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO Students
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams
VALUES 
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--Problem 4. Self-Referencing

CREATE TABLE Teachers
(
	TeacherID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(10),
	ManagerID INT,
	CONSTRAINT FK_ManagerId_TeacherID FOREIGN KEY(ManagerID)
	REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

--Problem 5. Online Store Database

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderID INT NOT NULL,
	ItemID INT NOT NULL,
	CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID),
	CONSTRAINT FK_OrderItems_Orders FOREIGN KEY(OrderID)
	REFERENCES Orders(OrderID),
	CONSTRAINT FK_OrderItems_Items FOREIGN KEY(ItemID)
	REFERENCES Items(ItemID)
)

--Problem 6. University Database
--MAJORS, STUDNETS, PAYMENTS  SUBJECT AGENDA

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	StudentNumber INT NOT NULL,
	StudnetName VARCHAR(10) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY,
	PaymentDate DATE NOT NULL,
	PaymentAmount INT NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY,
	SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda
(
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,
	CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID),
	CONSTRAINT FK_Agenda_Students FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_Agenda_Subjects FOREIGN KEY (SubjectID)
	REFERENCES Subjects(SubjectID)
)

--Problem 7. SoftUni Design
--Problem 8. Geography Design

--Check folder for diagrams

--Problem 9. *Peaks in Rila

USE Geography

SELECT a.MountainRange, b.PeakName, b.Elevation
FROM Mountains AS a
JOIN Peaks AS b ON (b.MountainID = a.Id)
WHERE a.MountainRange = 'Rila'
ORDER BY b.Elevation DESC











