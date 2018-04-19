/********************************************************************/
/********** 创建存储过程Sp_Insert_Note ******************************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Insert_Note' AND type = 'P')
	DROP PROCEDURE Sp_Insert_Note;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Insert_Note
	@AuthorId INT,
	@Title NVARCHAR(128),
	@Remark NVARCHAR(128),
	@IsShared BIT
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
			
		INSERT INTO Note(AuthorId, Title, Remark, CreateTime, LastBrowsedTime, IsShared, IsDeleted, DeletedTime)
			VALUES(@AuthorId, @Title, @Remark, GETDATE(), GETDATE(), @IsShared, 0, GETDATE());
		SELECT 
			Note.Id, 
			Note.AuthorId, 
			Note.Title, 
			Note.Remark, 
			Note.CreateTime, 
			Note.LastBrowsedTime, 
			Note.IsShared, 
			Note.IsDeleted, 
			Note.DeletedTime,
			(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = Note.Id) AS BrowsedTimes,
			(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Note.Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
			(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Note.Id AND NoteComment.IsDeleted = 0) AS CommentCount
		FROM Note 
		WHERE Note.Id = SCOPE_IDENTITY();
				
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
/********** 创建存储过程Sp_Select_NoteById **************************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteById' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteById;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteById
	@Id INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT 
		Note.Id, 
		Note.AuthorId, 
		Note.Title, 
		Note.Remark, 
		Note.CreateTime, 
		Note.LastBrowsedTime, 
		Note.IsShared, 
		Note.IsDeleted, 
		Note.DeletedTime,
		(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = Note.Id) AS BrowsedTimes,
		(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Note.Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
		(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Note.Id AND NoteComment.IsDeleted = 0) AS CommentCount
	FROM Note 
	WHERE Note.Id = @Id AND Note.IsDeleted = 0;
GO

/********************************************************************/
/********** 创建存储过程Sp_Select_NoteByAuthorId ********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteByAuthorId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteByAuthorId;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteByAuthorId
	@AuthorId INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	
	SELECT 
		Note.Id, 
		Note.AuthorId, 
		Note.Title, 
		Note.Remark, 
		Note.CreateTime, 
		Note.LastBrowsedTime, 
		Note.IsShared, 
		Note.IsDeleted, 
		Note.DeletedTime,
		(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = Note.Id) AS BrowsedTimes,
		(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Note.Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
		(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Note.Id AND NoteComment.IsDeleted = 0) AS CommentCount
	FROM Note 
	WHERE AuthorId = @AuthorId AND IsDeleted = 0;
GO

/********************************************************************/
/********** 创建存储过程Sp_Update_NoteGetBrowsed ********************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Update_NoteGetBrowsed' AND type = 'P')
	DROP PROCEDURE Sp_Update_NoteGetBrowsed;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Update_NoteGetBrowsed
	@NoteId INT,
	@UserId INT
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
	
		UPDATE Note SET Note.LastBrowsedTime = GETDATE() 
		WHERE Id = @NoteId AND AuthorId = @UserId AND IsDeleted = 0;
	
		INSERT INTO NoteBrowsedRecord(UserId, NoteId, BrowsedTime)
			VALUES(@UserId, @NoteId, GETDATE());
			
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
/********* 创建存储过程Sp_Select_NoteSearchByRemark *****************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteSearchByRemark' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteSearchByRemark;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteSearchByRemark
	@PageSize INT,
	@PageIndex INT,
	@SearchStr NVARCHAR(128)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	--声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
			
	IF @PageIndex <= 0 OR @PageSize <= 0
		RETURN;
		
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
		
		WITH tmp AS
		(
			SELECT *, ROW_NUMBER() OVER(ORDER BY Id) num, ROW_NUMBER() OVER(ORDER BY Id DESC) num_desc
			FROM Note
			WHERE Remark LIKE '%' + @SearchStr + '%'
		)
		
		SELECT 
			tmp.Id, 
			tmp.AuthorId, 
			tmp.Title, 
			tmp.Remark, 
			tmp.CreateTime, 
			tmp.LastBrowsedTime, 
			tmp.IsShared, 
			tmp.IsDeleted, 
			tmp.DeletedTime,
			(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = tmp.Id) AS BrowsedTimes,
			(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
			(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Id AND NoteComment.IsDeleted = 0) AS CommentCount,
			num_desc + num - 1 as TotalRow
		FROM tmp
		WHERE num BETWEEN ((@PageIndex - 1) * @PageSize) + 1 AND (@PageIndex * @PageSize)
		ORDER BY num;
		
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
GO

/********************************************************************/
/******* 创建存储过程Sp_Select_NoteSearchByRemarkAndAuthorId ********/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteSearchByRemarkAndAuthorId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteSearchByRemarkAndAuthorId;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteSearchByRemarkAndAuthorId
	@PageSize INT,
	@PageIndex INT,
	@SearchStr NVARCHAR(128),
	@AuthorId INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	--声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
			
	IF @PageIndex <= 0 OR @PageSize <= 0
		RETURN;
		
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
		
		WITH tmp AS
		(
			SELECT *, ROW_NUMBER() OVER(ORDER BY Id) num, ROW_NUMBER() OVER(ORDER BY Id DESC) num_desc
			FROM Note
			WHERE AuthorId = @AuthorId AND Remark LIKE '%' + @SearchStr + '%'
		)
		
		SELECT 
			tmp.Id, 
			tmp.AuthorId, 
			tmp.Title, 
			tmp.Remark, 
			tmp.CreateTime, 
			tmp.LastBrowsedTime, 
			tmp.IsShared, 
			tmp.IsDeleted, 
			tmp.DeletedTime,
			(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = tmp.Id) AS BrowsedTimes,
			(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
			(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Id AND NoteComment.IsDeleted = 0) AS CommentCount,
			num_desc + num - 1 as TotalRow
		FROM tmp
		WHERE num BETWEEN ((@PageIndex - 1) * @PageSize) + 1 AND (@PageIndex * @PageSize)
		ORDER BY num;
		
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
GO

/********************************************************************/
/********* 创建存储过程Sp_Select_NoteSearchByTitle ******************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteSearchByTitle' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteSearchByTitle;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteSearchByTitle
	@PageSize INT,
	@PageIndex INT,
	@SearchStr NVARCHAR(128)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	--声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
			
	IF @PageIndex <= 0 OR @PageSize <= 0
		RETURN;
		
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
		
		WITH tmp AS
		(
			SELECT *, ROW_NUMBER() OVER(ORDER BY Id) num, ROW_NUMBER() OVER(ORDER BY Id DESC) num_desc
			FROM Note
			WHERE Title LIKE '%' + @SearchStr + '%'
		)
		
		SELECT 
			tmp.Id, 
			tmp.AuthorId, 
			tmp.Title, 
			tmp.Remark, 
			tmp.CreateTime, 
			tmp.LastBrowsedTime, 
			tmp.IsShared, 
			tmp.IsDeleted, 
			tmp.DeletedTime,
			(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = tmp.Id) AS BrowsedTimes,
			(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
			(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Id AND NoteComment.IsDeleted = 0) AS CommentCount,
			num_desc + num - 1 as TotalRow
		FROM tmp
		WHERE num BETWEEN ((@PageIndex - 1) * @PageSize) + 1 AND (@PageIndex * @PageSize)
		ORDER BY num;
		
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
GO

/********************************************************************/
/****** 创建存储过程Sp_Select_NoteSearchByTitleAndAuthorId **********/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteSearchByTitleAndAuthorId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteSearchByTitleAndAuthorId;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteSearchByTitleAndAuthorId
	@PageSize INT,
	@PageIndex INT,
	@SearchStr NVARCHAR(128),
	@AuthorId INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	--声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
			
	IF @PageIndex <= 0 OR @PageSize <= 0
		RETURN;
		
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
		
		WITH tmp AS
		(
			SELECT *, ROW_NUMBER() OVER(ORDER BY Id) num, ROW_NUMBER() OVER(ORDER BY Id DESC) num_desc
			FROM Note
			WHERE AuthorId = @AuthorId AND Title LIKE '%' + @SearchStr + '%'
		)
		
		SELECT 
			tmp.Id, 
			tmp.AuthorId, 
			tmp.Title, 
			tmp.Remark, 
			tmp.CreateTime, 
			tmp.LastBrowsedTime, 
			tmp.IsShared, 
			tmp.IsDeleted, 
			tmp.DeletedTime,
			(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = tmp.Id) AS BrowsedTimes,
			(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
			(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Id AND NoteComment.IsDeleted = 0) AS CommentCount,
			num_desc + num - 1 as TotalRow
		FROM tmp
		WHERE num BETWEEN ((@PageIndex - 1) * @PageSize) + 1 AND (@PageIndex * @PageSize)
		ORDER BY num;
		
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
GO

/********************************************************************/
/*********** 创建存储过程Sp_Select_NoteSearchByTimeSpan *************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteSearchByTimeSpan' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteSearchByTimeSpan;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteSearchByTimeSpan
	@PageSize INT,
	@PageIndex INT,
	@StartTime DateTime,
	@EndTime DateTime
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	--声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
			
	IF @PageIndex <= 0 OR @PageSize <= 0
		RETURN;
		
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
		
		WITH tmp AS
		(
			SELECT *, ROW_NUMBER() OVER(ORDER BY Id) num, ROW_NUMBER() OVER(ORDER BY Id DESC) num_desc
			FROM Note
			WHERE CreateTime > @StartTime AND CreateTime < @EndTime
		)
		
		SELECT 
			tmp.Id, 
			tmp.AuthorId, 
			tmp.Title, 
			tmp.Remark, 
			tmp.CreateTime, 
			tmp.LastBrowsedTime, 
			tmp.IsShared, 
			tmp.IsDeleted, 
			tmp.DeletedTime,
			(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = tmp.Id) AS BrowsedTimes,
			(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
			(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Id AND NoteComment.IsDeleted = 0) AS CommentCount,
			num_desc + num - 1 as TotalRow
		FROM tmp
		WHERE num BETWEEN ((@PageIndex - 1) * @PageSize) + 1 AND (@PageIndex * @PageSize)
		ORDER BY num;
		
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
GO

/********************************************************************/
/**** 创建存储过程Sp_Select_NoteSearchByTimeSpanAndAuthorId *********/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteSearchByTimeSpanAndAuthorId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteSearchByTimeSpanAndAuthorId;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteSearchByTimeSpanAndAuthorId
	@PageSize INT,
	@PageIndex INT,
	@StartTime DateTime,
	@EndTime DateTime,
	@AuthorId INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	--声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
			
	IF @PageIndex <= 0 OR @PageSize <= 0
		RETURN;
		
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
		
		WITH tmp AS
		(
			SELECT *, ROW_NUMBER() OVER(ORDER BY Id) num, ROW_NUMBER() OVER(ORDER BY Id DESC) num_desc
			FROM Note
			WHERE AuthorId = @AuthorId AND CreateTime > @StartTime AND CreateTime < @EndTime
		)
		
		SELECT 
			tmp.Id, 
			tmp.AuthorId, 
			tmp.Title, 
			tmp.Remark, 
			tmp.CreateTime, 
			tmp.LastBrowsedTime, 
			tmp.IsShared, 
			tmp.IsDeleted, 
			tmp.DeletedTime,
			(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = tmp.Id) AS BrowsedTimes,
			(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
			(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Id AND NoteComment.IsDeleted = 0) AS CommentCount,
			num_desc + num - 1 as TotalRow
		FROM tmp
		WHERE num BETWEEN ((@PageIndex - 1) * @PageSize) + 1 AND (@PageIndex * @PageSize)
		ORDER BY num;
		
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
GO

/********************************************************************/
/********* 创建存储过程Sp_Select_NoteSearchByAuthorId ***************/
/********************************************************************/
IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Sp_Select_NoteSearchByAuthorId' AND type = 'P')
	DROP PROCEDURE Sp_Select_NoteSearchByAuthorId;
GO

USE MyNote
GO

CREATE PROCEDURE Sp_Select_NoteSearchByAuthorId
	@PageSize INT,
	@PageIndex INT,
	@AuthorId INT
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
	--声明变量，存放当前已开启的事务数
    DECLARE @exist_trancount int
    SELECT @exist_trancount = @@TRANCOUNT
			
	IF @PageIndex <= 0 OR @PageSize <= 0
		RETURN;
		
	BEGIN TRY
		IF(@exist_trancount = 0)
			BEGIN TRAN tran1;
		
		WITH tmp AS
		(
			SELECT *, ROW_NUMBER() OVER(ORDER BY Id) num, ROW_NUMBER() OVER(ORDER BY Id DESC) num_desc
			FROM Note
			WHERE AuthorId = @AuthorId
		)
		
		SELECT 
			tmp.Id, 
			tmp.AuthorId, 
			tmp.Title, 
			tmp.Remark, 
			tmp.CreateTime, 
			tmp.LastBrowsedTime, 
			tmp.IsShared, 
			tmp.IsDeleted, 
			tmp.DeletedTime,
			(SELECT COUNT(*) FROM NoteBrowsedRecord WHERE NoteBrowsedRecord.NoteId = tmp.Id) AS BrowsedTimes,
			(SELECT COUNT(*) FROM NoteApprovedRecord WHERE NoteApprovedRecord.NoteId = Id AND NoteApprovedRecord.IsCanceled = 0) AS ApprovedTimes,
			(SELECT COUNT(*) FROM NoteComment WHERE NoteComment.NoteId = Id AND NoteComment.IsDeleted = 0) AS CommentCount,
			num_desc + num - 1 as TotalRow
		FROM tmp
		WHERE num BETWEEN ((@PageIndex - 1) * @PageSize) + 1 AND (@PageIndex * @PageSize)
		ORDER BY num;
		
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
GO