Alter Proc Teacher.Proc_TeacherDetails(
@Flag		Varchar(100) = Null,
@FullName	Varchar(100) =Null,
@Address	Varchar(100) =Null,
@Mobileno	Varchar(15) =Null,
@Email		Varchar(50) =Null,
@Gender		Varchar(10) =Null,
@Sem		Varchar(10) =NULL,
@RowId		BIGINT		= NULL 
)
as Set NoCount On
IF @Flag='insert'
Begin
			Insert into Teacher.Tbl_TeacherDetails
				(FullName, Address, Mobileno,Email,Gender,Sem,CreatedDate)
			Select @FullName,@Address,@Mobileno,@Email,@Gender,@Sem,GetDate()
			SELECT '100' AS Code, 'Success'AS Message

END
Else If @Flag ='DropDown'
Begin
		select Text,Value from  Setup.Tbl_DropDown (NoLock) where StaticCode='Gender'

		select Text,Value from  Setup.Tbl_DropDown (NoLock) where StaticCode='Sem'
END
ELSE IF @Flag='GridList'
BEGIN

			SELECT ROW_NUMBER()OVER(ORDER BY TD.CreatedDate ASC) AS SNo, TD.RowId, TD.FullName, TD.Address, TD.Mobileno, TD.Email, Gender=GDD.Text, Sem=SDD.Text, TD.CreatedDate 
			FROM  Teacher.Tbl_TeacherDetails TD(NOLOCK)
			INNER JOIN Setup.Tbl_DropDown GDD(NOLOCK) ON GDD.Value = TD.Gender
			INNER JOIN Setup.Tbl_DropDown SDD(NOLOCK) ON SDD.Value = TD.Sem
END
ELSE IF @Flag='update'
BEGIN
			UPDATE Teacher.Tbl_TeacherDetails SET FullName = @FullName,
												  Address = @Address,
												  Mobileno =@Mobileno,
												  Email = @Email,
												  Gender = @Gender,
												  Sem = @Sem
												  WHERE RowId = @RowId
											SELECT '100' AS Code, 'Success'AS Message		 

END
ELSE IF @Flag='GetDetailsById'
BEGIN
		SELECT RowId, FullName, Address, Mobileno, Email, Gender, Sem, CreatedDate FROM Teacher.Tbl_TeacherDetails (NOLOCK) WHERE RowId =@RowId

END
