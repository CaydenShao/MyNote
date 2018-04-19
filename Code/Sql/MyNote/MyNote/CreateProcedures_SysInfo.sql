/********************************************************************/
/********** 创建存储过程Sp_Insert_SysConfig *************************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Insert_SysInfo' AND type = 'P')
	DROP PROCEDURE Sp_Insert_SysInfo;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Insert_SysInfo
	@Name NVARCHAR(128),
	@Description NVARCHAR(128),
	@Detail NVARCHAR
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
			
		INSERT INTO SysInfo(Name, [Description], Detail)
			VALUES(@Name, @Description, @Detail);
		SELECT Id, Name, [Description], Detail FROM SysInfo WHERE Id = SCOPE_IDENTITY();
		
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
/********** 创建存储过程Sp_Select_SysConfigById *************************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_SysInfoById' AND type = 'P')
	DROP PROCEDURE Sp_Select_SysInfoById
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_SysInfoById
	@Id INT
As
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, Name, [Description], Detail FROM SysInfo WHERE Id = @Id;
GO

/********************************************************************/
/********** 创建存储过程Sp_Select_SysConfigByName *************************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_SysInfoByName' AND type = 'P')
	DROP PROCEDURE Sp_Select_SysInfoByName;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_SysInfoByName
	@Name VARCHAR(128)
As
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, Name, [Description], Detail FROM SysInfo WHERE Name = @Name;
GO