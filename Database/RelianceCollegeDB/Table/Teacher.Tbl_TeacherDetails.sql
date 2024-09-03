Create Table Teacher.Tbl_TeacherDetails(
RowId  BigInt  Primary  Key  Identity(1,1) Not Null,
FullName			Varchar(100)  Null,
Address				Varchar(100)  null,
Mobileno			Varchar(15) Null,
Email				Varchar(50) Null,
Gender				Varchar(10) Null,
Sem					Varchar(10)  Null
)

Alter Table Teacher.Tbl_TeacherDetails
Add  CreatedDate DateTime Null