create database Day21_ADOdotNET
use Day21_ADOdotNET

create table Customer(
Id int identity(1,1) primary key,
Name varchar(200),
City varchar(200),
Address varchar(200),
MobileNumber bigint)

alter table Customer add Salary bigint;
select * from Customer;

CREATE PROCEDURE spAddCustomer
@Name varchar(30),
@City varchar(30),
@Address varchar(100),
@Phone bigint,
@Salary bigint
AS
INSERT INTO Customer(Name,City,Address,MobileNumber,Salary) VALUES (@Name,@City,@Address,@Phone,@Salary)

CREATE PROCEDURE spDeleteCustomer
@Name varchar(30)
AS
delete from Customer where Name=@Name

CREATE PROCEDURE spUpdateSalary
@Name varchar(30),
@Salary bigint
AS
UPDATE Customer SET Salary=@Salary where Name=@Name