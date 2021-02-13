CREATE TABLE Cars(
	CarID int PRIMARY KEY IDENTITY(1,1),
	CarName nvarchar(50),
	BrandID int,
	ColorID int,
	ModelYear nvarchar(25),
	DailyPrice decimal,
	Descriptions nvarchar(25),
	FOREIGN KEY (BrandID) REFERENCES Colors(ColorID),
	FOREIGN KEY (ColorID) REFERENCES Brands(BrandID)
)

CREATE TABLE Colors(
	ColorID int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

CREATE TABLE Brands(
	BrandID int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)


CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NULL,
    [CompanyName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserID])
);


CREATE TABLE [dbo].[Users] (
    [UserID]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NULL,
    [LastName]  NVARCHAR (50) NULL,
    [Email]     NVARCHAR (50) NULL,
    [Password]  NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);


CREATE TABLE [dbo].[Rentals] (
    [RentalId]   INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NULL,
    [CustomerId] INT      NULL,
    [RentDate]   DATETIME NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarID]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);



INSERT INTO Cars(BrandID,ColorID,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','2','2012','100','Manuel Benzin'),
	('1','3','2015','150','Otomatik Dizel'),
	('2','1','2017','200','Otomatik Hybrid'),
	('3','3','2014','125','Manuel Dizel');

INSERT INTO Colors(ColorName)
VALUES
	('Siyah'),
	('Gri'),
	('Kırmızı'),
	('Sarı'),
	('Beyaz'),
	('Mavi'),
	('Cyan'),
	('Gümüş');


INSERT INTO Brands(BrandName)
VALUES
	('Bmw'),
	('Renault'),
	('Mercedes'),
	('Toyota'),
	('Vosvogen');
	
INSERT INTO Rentals(CarId,CustomerId,RentDate,ReturnDate) VALUES 
(1,1,'2020-12-29 15:00:01','2021-01-05 16:16:05'),
(2,2,'2020-12-30 10:34:09',null),
(3,3,'2020-01-14 14:39:23','2020-01-20 12:02:48'),
(4,4,'2015-11-05 17:45:53',null),
(5,5,'2021-01-12 11:12:38','2021-01-16 18:01:41');


INSERT INTO Customers(UserId,CompanyName) VALUES 
	(1,'Türkiye Finans Katılım Bankası'),
	(2,'İş Bankası'),
	(3,'Çiçek Sepeti'),
	(4,'Yemek Sepeti'),
	(5,'Getir');

INSERT INTO Users(FirstName,LastName,Email,Password) VALUES 
	('Samet','Kaya','kaya67380@gmail.com','123samet'),
	('Mazlum','Arslan','mazlumarslan12@gmail.com','123mazlum'),
	('Serdar','Yazıcı','yazıcıserdar57@gmail.com','123serdar'),
	('Can','Güneri','cankuneri34@gmail.com','123Guneri'),
	('Berkant','Yılmaz','berkantyilmaz3484@gmail.com','123berkant');

