use master
go
create database testqlch
go
use testqlch
go
create table Category(
	ID int identity(0,1) primary key,
	[Name] nvarchar(50),
	IsDeleted bit default 0
)
go
create table Product(
	ID int identity(0,1) primary key,
	[Name] nvarchar(50),
	Details ntext,
	[Image] ntext,
	Cost int,
	IDCategory int constraint fk_cate foreign key(IDCategory) references Category(ID),
	IsDeleted bit default 0
)
