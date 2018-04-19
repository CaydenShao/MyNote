/********************************************************************/
/********** 创建存储过程Sp_Insert_FtpConfig *************************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Insert_FtpConfig' AND type = 'P')
	DROP PROCEDURE Sp_Insert_FtpConfig
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Insert_FtpConfig
	@Name NVARCHAR(128),
	@Discription NVARCHAR,
	@IP VARCHAR(15),
	@Port INT,
	@IsNeedAuthentication BIT,
    @VirticalDir NVARCHAR(128),
    @UserName NVARCHAR(128),
    @Password VARCHAR(128)
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
			
		INSERT INTO FtpConfig(Name, [Description], IP, Port, IsNeedAuthentication, VirticalDir, UserName, [Password])
			VALUES(@Name, @Discription, @IP, @Port, @IsNeedAuthentication, @VirticalDir, @UserName, @Password)
		SELECT Id, Name, [Description], IP, Port, IsNeedAuthentication, VirticalDir, UserName, [Password] 
			FROM FtpConfig WHERE Id = SCOPE_IDENTITY()
			
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
/********** 创建存储过程Sp_Select_FtpConfigById *********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_FtpConfigById' AND type = 'P')
	DROP PROCEDURE Sp_Select_FtpConfigById
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_FtpConfigById
	@Id INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

	SELECT Id, Name, [Description], IP, Port, IsNeedAuthentication, VirticalDir, UserName, [Password] 
		FROM FtpConfig WHERE Id = @Id
GO

/********************************************************************/
/********** 创建存储过程Sp_Select_FtpConfigByName *********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_FtpConfigByName' AND type = 'P')
	DROP PROCEDURE Sp_Select_FtpConfigByName
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_FtpConfigByName
	@Name NVARCHAR(128)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, Name, [Description], IP, Port, IsNeedAuthentication, VirticalDir, UserName, [Password] 
		FROM FtpConfig WHERE Name = @Name
GO