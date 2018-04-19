/********************************************************************/
/********** 创建存储过程Sp_IUGetApproved_NoteApprovedRecord *********/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_IUGetApproved_NoteApprovedRecord' AND type = 'P')
	DROP PROCEDURE Sp_IUGetApproved_NoteApprovedRecord;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_IUGetApproved_NoteApprovedRecord
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
			
		IF EXISTS(SELECT * FROM NoteApprovedRecord WHERE UserId = @UserId AND NoteId = @NoteId)
		BEGIN
			UPDATE NoteApprovedRecord SET ApprovedTime = GETDATE(), IsCanceled = 0 WHERE UserId = @UserId AND NoteId = @NoteId;
		END
		ELSE
		BEGIN
			INSERT INTO NoteApprovedRecord(UserId, NoteId, ApprovedTime, IsCanceled, CanceledTime)
				VALUES(@UserId, @NoteId, GETDATE(), 0, GETDATE());
			SELECT Id, UserId, NoteId, ApprovedTime, IsCanceled, CanceledTime FROM NoteApprovedRecord WHERE Id = SCOPE_IDENTITY();
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
/********** 创建存储过程Sp_UCancel_NoteApprovedRecord ***************/
/********************************************************************/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'Sp_UCancel_NoteApprovedRecord' AND type = 'P')
	DROP PROCEDURE Sp_UCancel_NoteApprovedRecord
GO

CREATE PROCEDURE Sp_UCancel_NoteApprovedRecord
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
			
		UPDATE NoteApprovedRecord SET IsCanceled = 1, CanceledTime = GETDATE() WHERE UserId = @UserId AND NoteId = @NoteId;
		SELECT Id, UserId, NoteId, ApprovedTime, IsCanceled, CanceledTime FROM NoteApprovedRecord WHERE UserId = @UserId AND NoteId = @NoteId;
		
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
/********** 创建存储过程Sp_Select_NoteApprovedRecordsByNoteId *******/
/********************************************************************/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'Sp_Select_NoteApprovedRecordsByNoteId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteApprovedRecordsByNoteId
GO

CREATE PROCEDURE Sp_Select_NoteApprovedRecordsByNoteId
	@NoteId INT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

	SELECT Id, UserId, NoteId, ApprovedTime, IsCanceled, CanceledTime FROM NoteApprovedRecord WHERE NoteId = @NoteId;
END
GO

/********************************************************************/
/********** 创建存储过程Sp_Select_NoteApprovedRecordsByNoteId *******/
/********************************************************************/
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'Sp_Select_NoteApprovedRecordsByUserId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteApprovedRecordsByUserId
GO

CREATE PROCEDURE Sp_Select_NoteApprovedRecordsByUserId
	@UserId INT
AS
BEGIN
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, UserId, NoteId, ApprovedTime, IsCanceled, CanceledTime FROM NoteApprovedRecord WHERE UserId = @UserId;
END
GO