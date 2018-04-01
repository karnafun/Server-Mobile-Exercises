/*
drop table sale, [User], ProductN, Category

The order matters because of the foreign keys ya noob ! 
*/
create table Category(
id int not null primary key,
[name] nvarchar(50) not null
)
go

create table ProductN (
productId smallint  not null ,
categoryId int not null,
title nvarchar(100) not null,
imagePath nvarchar(500) not null,
price float not null,
inventory int not null,
[status] bit not null,
primary key (productId),
foreign key (categoryId) references Category(id)
)
go

create table [User](
UserName nvarchar(50) not null,
[password] nvarchar(50) not null,
UserType nvarchar(50) not null,
primary key (UserName)
)
go


create table Sale (
saleId smallint identity not null,
productId smallint not null,
price float not null,
quantity int not null,
customer nvarchar(50) not null,
date datetime not null,
paymentMethod smallint not null,
primary key (saleId),
foreign key (customer) references [User](UserName),
foreign key (productId) references ProductN(productId)
)
go




--Insert Values
insert into [user] values ('admin','admin', 'admin')
insert into [user] values ('customer1','customer1', 'customer')
insert into [user] values ('customer2','customer2', 'customer')
insert into [user] values ('customer3','customer3', 'customer')
go

--insert into Category values(1,'Chair')
--insert into Category values(2,'Table')
--insert into Category values(3,'Armchair')
--insert into Category values(4,'Bed')
--insert into Category values(5,'Carpet')
--insert into Category values(6,'Shelf')
--insert into Category values(7,'Sofa')
--insert into Category values(8,'Stool')
--insert into Category values(9,'Wardrobe')


select * from ProductN
go

select * from sale
go

Insert into Sale (productId,price,quantity,customer,[date],paymentMethod)
values (20,20,1,'customer1','1/2/2018',1)
go

select * from sale
delete from sale
go

update ProductN
set inventory = 5
where productId = 20
go

create view SalesWithCategories
as
SELECT        dbo.Sale.saleId, dbo.ProductN.title, dbo.ProductN.categoryId, dbo.Category.name, dbo.Sale.price, dbo.Sale.quantity, dbo.Sale.customer, dbo.Sale.date, dbo.Sale.paymentMethod
FROM            dbo.ProductN INNER JOIN
                         dbo.Category ON dbo.ProductN.categoryId = dbo.Category.id INNER JOIN
                         dbo.Sale ON dbo.ProductN.productId = dbo.Sale.productId
go
