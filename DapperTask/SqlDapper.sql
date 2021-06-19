Create table Countries(
CountryCode nvarchar(2) Primary Key,
[Name] nvarchar(128)
);
Go
Create table Users(
Id int Primary Key,
FullName nvarchar(128),
Email nvarchar(128) UNIQUE,
Gender nvarchar(50),
DateOfBirthday Date,
CountryCode nvarchar(2) References Countries(CountryCode),
CreatedAt Date
);
GO		
Create table Merchants(
Id int Primary Key,
[Name] nvarchar(128),
CountryCode nvarchar(2) References Countries(CountryCode),
CreatedAt Date,
UserId int References Users(Id) NULL
);
GO
Create table Products(
Id int Primary key,
MerchantId int references Merchants(Id),
[Name] nvarchar(128),
Price Decimal,
[Status] nvarchar(128),
CreatedAt Date
);
GO
Create table Orders(
Id int Primary key,
UserId int References Users(Id),
[Status] nvarchar(128),
CreatedAt Date,
OrderJson nvarchar(MAX)
);

GO
Create table OrderItems(
OrderId int references Orders(Id),
ProductId int references Products(Id),
Quantity int
);