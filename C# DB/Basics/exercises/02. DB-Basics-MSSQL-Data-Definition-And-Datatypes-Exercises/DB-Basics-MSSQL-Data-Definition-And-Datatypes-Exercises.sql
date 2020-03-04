/* 1. Create Database */

CREATE DATABASE Minions

/* 2. Create Tables */

USE Minions

CREATE TABLE Minions 
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name VARCHAR(30),
	Age INT
)

CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name VARCHAR(30)
)

/* 3. Alter Minions Table */

ALTER TABLE Minions 
ADD TownId INT NOT NULL;

ALTER TABLE Minions
ADD CONSTRAINT FK_TownId FOREIGN KEY (TownId)
REFERENCES Towns (Id)

/* 4. Insert Records in Both Tables */

INSERT INTO Towns
VALUES
('Sofia'),
('Plovdiv'),
('Varna')

INSERT INTO Minions
VALUES 
('Kevin', 22, 1),
('Bob', 15, 3),
('Steward', NULL, 2)

/* 5. Truncate Table Minions */

TRUNCATE TABLE Minions

/* 6. Drop All Tables */

DROP TABLE Minions
DROP TABLE Towns

/* 7. Create Table People */

CREATE TABLE People
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	Weight DECIMAL(5,2),
	Gender BIT NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People
VALUES 
('Kevin', NULL, 1.80, 99.50, 1,'2018-06-15','The memoirs of a geisha'),
('Andre', NULL, 1.85, 85.50, 1,'2018-05-15','The memoirs of a swordsman'),
('John', NULL, 1.90, 80.50, 1,'2018-04-15','The memoirs of a knight'),
('Joe', NULL, 1.95, 75.50, 1,'2018-03-15','The memoirs of a general'),
('Richard', NULL, 2.00, 70.50, 1,'2018-02-15','The memoirs of a marine')

/* 8. Create Table Users */

CREATE TABLE Users 
(
	Id BIGINT IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT,
	CONSTRAINT PK_Users PRIMARY KEY (Id)
)

INSERT INTO Users
VALUES 
('Pesho', '1234', NULL, NULL, 0),
('Gosho', '1234', NULL, NULL, 0),
('Toshho', '1234', NULL, NULL, 0),
('Losho', '1234', NULL, NULL, 0),
('Kyosho', '1234', NULL, NULL, 0)

/* 9. Change Primary Key */

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)

/* 10. Add Check Constraint */

ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordSize CHECK (DATALENGTH(Password) >= 5)

/* 11. Set Default Value of a Field */

ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

/* 12. Set Unique Field */

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CHK_Username CHECK (DATALENGTH(Username) >= 3)

/* 13. Movies Database */

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	DirectorName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	GenreName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Title VARCHAR(30) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT NOT NULL,
	Length INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes VARCHAR(MAX)
)

ALTER TABLE Movies
ADD CONSTRAINT FK_DirectorId FOREIGN KEY(DirectorId)
REFERENCES Directors(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_GenreId FOREIGN KEY(GenreId)
REFERENCES Genres(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_CategoryId FOREIGN KEY(CategoryId)
REFERENCES Categories(Id)

INSERT INTO Directors
VALUES
('John', NULL),
('Jack', NULL),
('Josh', NULL),
('Jonathan', NULL),
('Jorgen', NULL)

INSERT INTO Genres
VALUES
('Thriller', NULL),
('Sci-fi', NULL),
('Action', NULL),
('Comedy', NULL),
('Drama', NULL)

INSERT INTO Categories
VALUES
('First category', NULL),
('Second category', NULL),
('Third category', NULL),
('Fourth category', NULL),
('Fifth category', NULL)

INSERT INTO Movies
VALUES
('Inception', 1, 2010, 120, 3, 1, NULL, NULL),
('Equilbrium', 1, 2002, 112, 2, 2, NULL, NULL),
('Predator', 1, 1987, 100, 3, 3, NULL, NULL),
('Batman Begins', 1, 2005, 120, 3, 4, NULL, NULL),
('Escape Plan', 1, 2013, 100, 3, 1, NULL, NULL)

/* 14. Car Rental Database */

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(30) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MonthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL
)

CREATE TABLE Cars
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	PlateNumber INT NOT NULL,
	Manufacturer VARCHAR(15) NOT NULL,
	Model VARCHAR(15) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(10) NOT NULL,
	Available BIT NOT NULL
)

ALTER TABLE Cars
ADD CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId)
REFERENCES Categories(Id)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName VARCHAR(12) NOT NULL,
	LastName VARCHAR(12) NOT NULL,
	Title VARCHAR(15) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	DriverLicenceNumber INT NOT NULL,
	FullName VARCHAR(24) NOT NULL,
	Address VARCHAR(50) NOT NULL,
	City VARCHAR(12) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel VARCHAR(10) NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(5,2) NOT NULL,
	TaxRate DECIMAL(4,2) NOT NULL,
	OrderStatus VARCHAR(9) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Categories
VALUES
('Sportscar', 50, 350, 1500, 60),
('Affordable', 10, 100, 500, 15),
('Luxurious', 100 , 1000 , 5000, 110)

INSERT INTO Cars
VALUES
(1234, 'BMW', 'M6', 2015, 1, 2, NULL, 'Good', 1),
(5678, 'BMW', 'M3', 2017, 2, 2, NULL, 'Very good', 0),
(9038, 'BMW', 'M5', 2018, 3, 2, NULL, 'Excellent', 1)

INSERT INTO Employees
VALUES
('Pesho', 'Peshev', 'Salesman', NULL),
('Petyr', 'Geshev', 'Techsupport', NULL),
('Mani', 'Gerov', 'Manager', NULL)

INSERT INTO Customers
VALUES
(23234, 'Genadi Mitev', 'Nqkyde tam', 'Sofia', '2323', NULL),
(49856, 'Ganash Kitev', 'Nqkyde tuk', 'Rebrovo', '4564', NULL),
(12485, 'Gancho Gichev', 'Nqkyde sym', 'London', '4985', NULL)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 2, 3, 'Full', 0, 50, 50, '2018-06-15', '2018-07-15', 30, 30.50, 15.2, 'Pending', NULL),
(2, 3, 1, 'Empty', 0, 40, 70, '2018-03-15', '2018-04-15', 30, 22.50, 7.2, 'Completed', NULL),
(3, 1, 2, 'Half-Full', 0, 30, 60, '2018-02-15', '2018-03-15', 15, 20.50, 10.2, 'Failed', NULL)

/* 15. Hotel Database */

CREATE DATABASE Hotel

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName VARCHAR(12) NOT NULL,
	LastName VARCHAR(12) NOT NULL,
	Title VARCHAR(15) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	AccountNumber INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(12) NOT NULL,
	LastName VARCHAR(12) NOT NULL,
	PhoneNumber INT NOT NULL,
	EmergencyName VARCHAR(15),
	EmergencyNumber INT,
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(10) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(10) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedType VARCHAR(10) PRIMARY KEY,
	Notes VARCHAR(MAX)
)

CREATE TABLE Rooms
(
	RoomNumber INT IDENTITY PRIMARY KEY,
	RoomType VARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType VARCHAR(10) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate INT NOT NULL,
	RoomStatus VARCHAR(10) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Payments
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccuppied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged INT NOT NULL,
	TaxRate INT NOT NULL,
	TaxAmount INT NOT NULL,
	PaymentTotal INT NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Occupancies
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied INT NOT NULL,
	PhoneCharge INT,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees
VALUES
('Jack', 'Jones', 'Receptionist', NULL),
('Jax', 'Jonas', 'Manager', NULL),
('Jackie', 'Jakkur', 'Piccolo', NULL)

INSERT INTO Customers
VALUES
('Pesho', 'Peshev', 0888888888, NULL, NULL, NULL),
('Pesho', 'Pesheviq', 0888888889, NULL, NULL, NULL),
('Pesho', 'Peshankov', 0888888887, NULL, NULL, NULL)

INSERT INTO RoomStatus
VALUES
('Occupied', NULL),
('Free', NULL),
('ASD', NULL)

INSERT INTO RoomTypes
VALUES
('Cozy', NULL),
('ASD', NULL),
('Luxurous', NULL)

INSERT INTO BedTypes
VALUES
('Waterbed', NULL),
('Huge', NULL),
('Massive', NULL)

INSERT INTO Rooms
VALUES
('Cozy', 'Huge', 3, 'Free', NULL),
('ASD', 'Waterbed', 2, 'Occupied', NULL),
('Luxurous', 'Massive', 5, 'ASD', NULL)

INSERT INTO Payments
VALUES
(1, '2018-06-15', 2, '2018-04-15', '2018-03-15', 20, 50, 2, 10, 100, NULL),
(2, '2018-06-15', 1, '2018-02-15', '2018-01-15', 20, 30, 2, 8, 115, NULL),
(3, '2018-06-15', 3, '2018-05-15', '2018-06-15', 20, 40, 1, 9, 110, NULL)

INSERT INTO Occupancies
VALUES
(3, '2018-03-01', 2, 1, 50, NULL, NULL),
(2, '2018-03-01', 1, 2, 50, NULL, NULL),
(1, '2018-03-01', 3, 3, 50, NULL, NULL)

/* 16. Create SoftUni Database */

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns
(
	Id INT IDENTITY NOT NULL,
	Name VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY (Id)
)

CREATE TABLE Addresses
(
	Id INT IDENTITY NOT NULL,
	AddressText VARCHAR(MAX) NOT NULL,
	TownId INT NOT NULL,
	CONSTRAINT PK_Addresses PRIMARY KEY(Id),
	CONSTRAINT FK_TownId FOREIGN KEY (TownId)
	REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT IDENTITY NOT NULL,
	Name VARCHAR(30),
	CONSTRAINT PK_Departments PRIMARY KEY(Id)
)

CREATE TABLE Employees
(
	Id INT IDENTITY NOT NULL,
	FirstName VARCHAR(12) NOT NULL,
	MiddleName VARCHAR(12) NOT NULL,
	LastName VARCHAR(12) NOT NULL,
	JobTitle VARCHAR(15) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(6,2) NOT NULL,
	AddressId INT NOT NULL,
	CONSTRAINT PK_Employees PRIMARY KEY(Id),
	CONSTRAINT FK_DepartmentId FOREIGN KEY(DepartmentId)
	REFERENCES Departments(Id),
	CONSTRAINT FK_AddressId FOREIGN KEY(AddressId)
	REFERENCES Addresses(Id)
)

/* 17. Backup Database - check folder for backup*/

/* 18. Basic Insert */

INSERT INTO Towns
VALUES 
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Addresses
VALUES
('Sofia', 1)

INSERT INTO Departments
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, 1),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, 1),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 1),
('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 1),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 1)

/* 19. Basic Select All Fields */

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

/* 20. Basic Select All Fields and Order Them */

SELECT * FROM Towns
ORDER BY Name

SELECT * FROM Departments
ORDER BY Name

SELECT * FROM Employees
ORDER BY Salary DESC

/* 21. Basic Select Some Fields */

SELECT Name
FROM Towns
ORDER BY Name

SELECT Name
FROM Departments
ORDER BY Name

SELECT FirstName, LastName, JobTitle, Salary
FROM Employees
ORDER BY Salary DESC

/* 22. Increase Employees Salary */

USE SoftUni

UPDATE Employees
SET Salary += Salary * 0.10 

SELECT Salary
FROM Employees

/* 23. Decrease TaxRate */

USE Hotel

UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate
FROM Payments

/* 24. Delete All Records */

TRUNCATE TABLE Occupancies













