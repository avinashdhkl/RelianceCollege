Create Proc Teacher.Proc_TeacherDetails(
@Flag		Varchar(100) = Null,
@FullName	Varchar(100) =Null,
@Address	Varchar(100) =Null,
@Mobileno	Varchar(15) =Null,
@Email		Varchar(50) =Null,
@Gender		Varchar(10) =Null,
@Sem		Varchar(10) =Null
)
as Set NoCount On
IF @Flag='insert'
Begin
			Insert into Teacher.Tbl_TeacherDetails
				(FullName, Address, Mobileno,Email,Gender,Sem,CreatedDate)
			Select @FullName,@Address,@Mobileno,@Email,@Gender,@Sem,GetDate()

END
Else If @Flag ='DropDown'
Begin
		select Text,Value from  Setup.Tbl_DropDown (NoLock) where StaticCode='Gender'

		select Text,Value from  Setup.Tbl_DropDown (NoLock) where StaticCode='Sem'
END
