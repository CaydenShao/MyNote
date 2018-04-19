/********************************************************************/
/********** 创建存储过程Sp_Insert_NoteUser **************************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Insert_NoteUser' AND type = 'P')
	DROP PROCEDURE Sp_Insert_NoteUser;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Insert_NoteUser
	@Name NVARCHAR(128),
	@PhoneNumber VARCHAR(128),
	@HashCode NVARCHAR(128),
	@Salt NVARCHAR(128),
	@LastLoginAddress VARCHAR(15)
As
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
    --声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
    
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
			
		INSERT INTO NoteUser(Name, PhoneNumber, Email, ProfilePicture, HashCode, CreateTime, LastLoginTime, Salt, LastLoginAddress, Token, VerificationCode)
			VALUES(@Name, @PhoneNumber, NULL, NULL, @HashCode, GETDATE(), GETDATE(), @Salt, @LastLoginAddress, NEWID(), NULL);
		SELECT Id, Name, PhoneNumber, Email, ProfilePicture, HashCode, Salt, CreateTime, LastLoginTime, LastLoginAddress, Token, VerificationCode 
			FROM NoteUser WHERE Id = SCOPE_IDENTITY();
			
		IF(@exist_trancount = 0)
			COMMIT TRAN tran1;
	END TRY
	BEGIN CATCH
		IF(@exist_trancount = 0)
			ROLLBACK TRAN tran1;
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage,  -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState     -- State.
               );
	END CATCH
END
GO

/***********************************************************************/
/***********创建存储过程Sp_Select_NoteUserById**************************/
/***********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteUserById' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteUserById;
GO

USE MyNote
GO
	
CREATE PROCEDURE Sp_Select_NoteUserById
	@Id VARCHAR(128)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, Name, PhoneNumber, Email, ProfilePicture, HashCode, Salt, CreateTime, LastLoginTime, LastLoginAddress, Token, VerificationCode
		FROM NoteUser WHERE Id = @Id;
GO

/***********************************************************************/
/***********创建存储过程Sp_Select_NoteUserByPhoneNumber*****************/
/***********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteUserByPhoneNumber' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteUserByPhoneNumber;
GO

USE MyNote
GO
	
CREATE PROCEDURE Sp_Select_NoteUserByPhoneNumber
	@PhoneNumber VARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, Name, PhoneNumber, Email, ProfilePicture, HashCode, Salt, CreateTime, LastLoginTime, LastLoginAddress, Token, VerificationCode 
		FROM NoteUser WHERE PhoneNumber = @PhoneNumber;
END
GO

/***********************************************************************/
/***********创建存储过程Sp_Select_NoteUserByToken***********************/
/***********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteUserByToken' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteUserByToken;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteUserByToken
	@Token VARCHAR(128)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, Name, PhoneNumber, Email, ProfilePicture, HashCode, Salt, CreateTime, LastLoginTime, LastLoginAddress, Token, VerificationCode 
		FROM NoteUser WHERE Token = @Token;
GO
	
/***********************************************************************/
/***********创建存储过程Sp_Select_NoteUserByToken***********************/
/***********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteUserByIdAndToken' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteUserByIdAndToken;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteUserByIdAndToken
	@Id VARCHAR(128),
	@Token VARCHAR(128)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, Name, PhoneNumber, Email, ProfilePicture, HashCode, Salt, CreateTime, LastLoginTime, LastLoginAddress, Token, VerificationCode 
		FROM NoteUser WHERE Id = @Id And Token = @Token;
GO

/***********************************************************************/
/***********创建存储过程Sp_Update_NoteUserToken*************************/
/***********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Update_NoteUserToken' AND type = 'P')
	DROP PROCEDURE Sp_Update_NoteUserToken;
GO

CREATE PROCEDURE Sp_Update_NoteUserToken
	@Id INT,
	@Token VARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	--声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
    
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
			
		UPDATE NoteUser SET Token = @Token WHERE Id = @Id;
		SELECT Id, Name, PhoneNumber, Email, ProfilePicture, HashCode, Salt, CreateTime, LastLoginTime, LastLoginAddress, Token, VerificationCode 
			FROM NoteUser WHERE Id = @Id;
			
		IF(@exist_trancount = 0)
			COMMIT TRAN tran1;
	END TRY
	BEGIN CATCH
		IF(@exist_trancount = 0)
			ROLLBACK TRAN tran1;
		
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		RAISERROR (@ErrorMessage,  -- Message text.
               @ErrorSeverity, -- Severity.
               @ErrorState     -- State.
               );
	END CATCH
END
GO