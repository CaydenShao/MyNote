/********************************************************************/
/********** 创建存储过程Sp_Insert_CommentContent ***********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Insert_CommentContent' AND type = 'P')
	DROP PROCEDURE Sp_Insert_CommentContent;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Insert_CommentContent
	@CommentId INT,
	@Type INT,
	@Content INT
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
			
		INSERT INTO CommentContent(CommentId, [Type], Content, CreateTime)
			VALUES(@CommentId, @Type, @Content, GETDATE());
		SELECT Id, CommentId, [Type], Content, CreateTime FROM CommentContent WHERE Id = SCOPE_IDENTITY();
		
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
/********** 创建存储过程Sp_Select_CommentContentById ***********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_CommentContentById' AND type = 'P')
	DROP PROCEDURE Sp_Select_CommentContentById;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_CommentContentById
	@Id INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, CommentId, [Type], Content, CreateTime FROM CommentContent WHERE Id = @Id;
GO

/********************************************************************/
/********** 创建存储过程Sp_Select_CommentContentByCommentId ***********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_CommentContentByCommentId' AND type = 'P')
	DROP PROCEDURE Sp_Select_CommentContentByCommentId;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_CommentContentByCommentId
	@CommentId INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT Id, CommentId, [Type], Content, CreateTime FROM CommentContent WHERE CommentId = @CommentId;
GO