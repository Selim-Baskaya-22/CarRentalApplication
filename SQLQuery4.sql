CREATE DATABASE CarsRental

CREATE TABLE Brands(
    BrandsId INT IDENTITY PRIMARY KEY NOT NULL,
    Name varchar(50),
);

CREATE TABLE Colors (
    ColorsId INT IDENTITY PRIMARY KEY NOT NULL,
    Name varchar(30),
	
);
CREATE TABLE Cars (
    CarsId INT IDENTITY PRIMARY KEY NOT NULL,
    ModelYear int,
	BrandsId int,
	ColorsId int,
    DailyPrice decimal,
    Description varchar(100),
	CONSTRAINT fkBrands FOREIGN KEY(BrandsId) REFERENCES Brands(BrandsId),
	CONSTRAINT fkColors FOREIGN KEY(ColorsId) REFERENCES Colors(ColorsId),
);

CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY NOT NULL,
    FirstName varchar(30),
	LastName varchar(30),
	Email varchar(100),
	Passwordd varchar(50),
);


CREATE TABLE Customer (
	CustomerId int primary key identity(1,1),
    UserId INT  NOT NULL,
    CompanyName varchar(50),
    CONSTRAINT fkCustomerId FOREIGN KEY(UserId) REFERENCES Users(UserId),
);

CREATE TABLE Rentals (
    Id INT IDENTITY PRIMARY KEY NOT NULL,
	CarId INT NOT NULL,
    CustomerId INT  NOT NULL,
	RentDate DATETIME DEFAULT(getdate()),
	ReturnDate DATETIME DEFAULT(getdate()),
	CONSTRAINT fkcusstomer_ıd FOREIGN KEY(CustomerId) REFERENCES Customer(CustomerId),
	CONSTRAINT fk_ccar_ıd FOREIGN KEY(CarId) REFERENCES Cars(CarId),
);

CREATE TABLE CarImages(
Id INT IDENTITY (1,1) PRIMARY KEY,
CarId INT NOT NULL,
ImagePath  NVARCHAR (MAX),
[Date] DATETIME,
CONSTRAINT fkCarImages FOREIGN KEY(CarId) REFERENCES Cars(CarId)
);

INSERT INTO Brands VALUES('Fiat');
INSERT INTO Brands VALUES('Mercedes');
INSERT INTO Brands VALUES('Volvo');
INSERT INTO Brands VALUES('Audi');
INSERT INTO Brands VALUES('Ford');

INSERT INTO Colors VALUES('Mavi');
INSERT INTO Colors VALUES('Sarı');
INSERT INTO Colors VALUES('Yeşil');
INSERT INTO Colors VALUES('Kırmızı');
INSERT INTO Colors VALUES('Beyaz');
INSERT INTO Colors VALUES('Turuncu');

INSERT INTO Cars VALUES(2010,1,1,500,'Hızlı araç');
INSERT INTO Cars VALUES(2011,1,1,600,'Yavaş araç');
INSERT INTO Cars VALUES(2012,2,3,700,'Lüks araç');
INSERT INTO Cars VALUES(2013,2,3,800,'Ucuz araç');
INSERT INTO Cars VALUES(2014,3,2,900,'Pahalı araç');
INSERT INTO Cars VALUES(2015,3,2,1000,'Benzinli araç');
INSERT INTO Cars VALUES(2016,4,5,1200,'Dizel araç');
INSERT INTO Cars VALUES(2017,4,4,1400,'Hızlı ve Konforlu araç');
INSERT INTO Cars VALUES(2018,5,4,1500,'Ekstra Lüks araç');

insert into Users values('Selim','Başkaya','selimbaskaya@gmail.com','selim1234')
insert into Users values('Evren','Burak','evrenburkkk@gmail.com','evren1234')
insert into Users values('Enes','Kızmaz','eneskızmazz@outlook.com','12enes12')
insert into Users values('Yiğithan','İnal','yigittinall@hotmail.com','12promister12')
insert into Users values('Zerin','Okcu','okcuzerrin@hotmail.com','miklede2323')
insert into Users values('Tunahan','Önen','önentuna@gmail.com','fener1907')


insert into customer values(1,'Teknosa')
insert into customer values(2,'Akusta')
insert into customer values(3,'Extreme Audio')
insert into customer values(4,'Bimeks')
insert into customer values(5,'Formnet')
insert into customer values(6,'Best Buy')

insert into Rentals(CarId,CustomerId) values(1,1)
insert into Rentals(CarId,CustomerId) values(2,2)
insert into Rentals(CarId,CustomerId) values(3,3)
