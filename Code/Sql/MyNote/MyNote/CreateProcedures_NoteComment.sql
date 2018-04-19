/********************************************************************/
/********** 创建存储过程Sp_Insert_NoteComment ***********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Insert_NoteComment' AND type = 'P')
	DROP PROCEDURE Sp_Insert_NoteComment;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Insert_NoteComment
	@NoteId INT,
	@CreatorId INT,
	@CommentId INT
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
			
		INSERT INTO NoteComment(NoteId, CreatorId, CommentId, CreateTime, IsDeleted, DeletedTime)
			VALUES(@NoteId, @CreatorId, @CommentId, GETDATE(), 0, GETDATE());
		SELECT Id, NoteId, CreatorId, CommentId, CreateTime, IsDeleted, DeletedTime 
			FROM NoteComment WHERE Id = SCOPE_IDENTITY();
		
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
/********** 创建存储过程Sp_Select_NoteCommentById ***********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteCommentById' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteCommentById;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteCommentById
	@Id INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, NoteId, CreatorId, CommentId, CreateTime, IsDeleted, DeletedTime 
		FROM NoteComment WHERE Id = @Id AND IsDeleted = 0;
GO

/********************************************************************/
/********** 创建存储过程Sp_Select_NoteCommentByNoteId ***********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteCommentByNoteId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteCommentByNoteId;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteCommentByNoteId
	@NoteId INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, NoteId, CreatorId, CommentId, CreateTime, IsDeleted, DeletedTime 
		FROM NoteComment WHERE NoteId = @NoteId AND IsDeleted = 0;
GO