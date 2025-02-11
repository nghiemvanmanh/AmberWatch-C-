use AmberWatch

Create table tbl_Account(
	Id INT Primary key identity(1,1),
	UserName NVARCHAR(255) Not null unique,
	PassWord NVARCHAR(255),
	SDT Varchar(10) CHECK (SDT LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	FullName Nvarchar(max) not null,
	Address Nvarchar(max) not null,
)


Insert into tbl_Account(UserName,PassWord,SDT,FullName, Address) values ('admin','2003','0999999999',N'Nghiêm Văn Mạnh',N'Hà Nội')