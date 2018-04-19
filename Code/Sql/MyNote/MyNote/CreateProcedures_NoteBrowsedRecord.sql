/********************************************************************/
/********** 创建存储过程Sp_Add_NoteBrowsedRecord *********/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Add_NoteBrowsedRecord' AND type = 'P')
	DROP PROCEDURE Sp_Add_NoteBrowsedRecord
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Add_NoteBrowsedRecord
	@UserId INT,
	@NoteId INT
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
			
		INSERT INTO NoteBrowsedRecord(UserId, NoteId, BrowsedTime)
			VALUES(@UserId, @NoteId, GETDATE())
		SELECT Id, UserId, NoteId, BrowsedTime FROM NoteBrowsedRecord WHERE Id = SCOPE_IDENTITY()
		
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
/********* 创建存储过程Sp_Select_NoteBrowsedRecordsByNoteId *********/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteBrowsedRecordsByNoteId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteBrowsedRecordsByNoteId
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteBrowsedRecordsByNoteId
	@NoteId INT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

	SELECT Id, UserId, NoteId, BrowsedTime FROM NoteBrowsedRecord WHERE NoteId = @NoteId;
END
GO

/********************************************************************/
/********* 创建存储过程Sp_Select_NoteBrowsedRecordsByUserId *********/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteBrowsedRecordsByUserId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteBrowsedRecordsByUserId
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteBrowsedRecordsByUserId
	@UserId INT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, UserId, NoteId, BrowsedTime FROM NoteBrowsedRecord WHERE UserId = @UserId;
END
GO