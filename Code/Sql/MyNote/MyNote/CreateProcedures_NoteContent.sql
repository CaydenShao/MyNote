/********************************************************************/
/********** 创建存储过程Sp_Insert_NoteContent ***********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Insert_NoteContent' AND type = 'P')
	DROP PROCEDURE Sp_Insert_NoteContent;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Insert_NoteContent
	@NoteId INT,
	@Type INT,
	@Content NVARCHAR(1024)
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
			
		INSERT INTO NoteContent(NoteId, [Type], Content, CreateTime, IsDeleted, DeletedTime)
			VALUES(@NoteId, @Type, @Content, GETDATE(), 0, GETDATE());
		SELECT Id, NoteId, [Type], Content, CreateTime, IsDeleted, DeletedTime 
			FROM NoteContent WHERE Id = SCOPE_IDENTITY();
			
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
/********** 创建存储过程Sp_Select_NoteContentById *******************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteContentById' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteContentById;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteContentById
	@Id INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, NoteId, [Type], Content, CreateTime, IsDeleted, DeletedTime 
		FROM NoteContent WHERE Id = @Id AND IsDeleted = 0;
GO

/********************************************************************/
/********** 创建存储过程Sp_Select_NoteContentByNoteId *******************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteContentByNoteId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteContentByNoteId;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteContentByNoteId
	@NoteId INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, NoteId, [Type], Content, CreateTime, IsDeleted, DeletedTime 
		FROM NoteContent WHERE NoteId = @NoteId AND IsDeleted = 0;
GO