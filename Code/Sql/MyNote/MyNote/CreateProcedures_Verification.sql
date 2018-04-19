/********************************************************************/
/********** 创建存储过程Sp_Put_Verification **********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Put_Verification' AND type = 'P')
	DROP PROCEDURE Sp_Put_Verification;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Put_Verification
	@PhoneNumber VARCHAR(128),
	@Code VARCHAR(128)
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
			
		if(EXISTS(SELECT * FROM Verification WHERE PhoneNumber = @PhoneNumber))
		BEGIN
			UPDATE Verification SET StartTime = GETDATE(), Code = @Code WHERE PhoneNumber = @PhoneNumber;
			SELECT Id, PhoneNumber, StartTime, Code FROM Verification WHERE PhoneNumber = @PhoneNumber;
		END
		ELSE
		BEGIN
			INSERT INTO Verification(PhoneNumber, StartTime, Code)
				VALUES(@PhoneNumber, GETDATE(), @Code);
			SELECT Id, PhoneNumber, StartTime, Code FROM Verification WHERE Id = SCOPE_IDENTITY();
		END
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

/********************************************************************/
/********** 创建存储过程Sp_Select_VerificationById **********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_VerificationById' AND type = 'P')
	DROP PROCEDURE Sp_Select_VerificationById;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_VerificationById
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
		
	SELECT Id, PhoneNumber, StartTime, Code FROM Verification WHERE Id = @Id;
END
GO

/********************************************************************/
/****** 创建存储过程Sp_Select_VerificationByPhoneNumber *************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_VerificationByPhoneNumber' AND type = 'P')
	DROP PROCEDURE Sp_Select_VerificationByPhoneNumber;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_VerificationByPhoneNumber
	@PhoneNumber VARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
		
	SELECT Id, PhoneNumber, StartTime, Code FROM Verification WHERE PhoneNumber = @PhoneNumber;
END
GO