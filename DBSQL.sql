Create Table Title
( ID int not null primary key,
  Description varchar(10) not null)


Create table People
( ID int not null primary key,
  TitleID int not null,
  FName varchar(15) not null, 
  LName varchar(15) not null)

Alter table People add constraint fk_people_title foreign key (TitleID) references Title(ID)



Insert into Title values (1, 'Mr');
Insert into Title values (2, 'Mrs');

Insert into People Values(1, 1, 'Person 1','Surname 1')
Insert into People Values(2, 2, 'Person 2','Surname 2')
Go

Create procedure GetPeople
As
Begin
Select p.ID, 
	   t.Description, 
	   p.FName, 
	   p.LName 
  from People p 
		inner join Title t on t.ID = p.TitleID
end
Go