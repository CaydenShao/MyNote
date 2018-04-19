USE MyNote;
GO

IF OBJECT_ID('SysInfo', 'U') IS NOT NULL
	DROP TABLE SysInfo
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'SysInfo')
--	DROP TABLE SysInfo

IF OBJECT_ID('FtpConfig', 'U') IS NOT NULL
	DROP TABLE FtpConfig
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'FtpConfig')
--	DROP TABLE FtpConfig

IF OBJECT_ID('NoteApprovedRecord', 'U') IS NOT NULL
	DROP TABLE NoteApprovedRecord
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'NoteApprovedRecord')
--	DROP TABLE NoteApprovedRecord

IF OBJECT_ID('NoteBrowsedRecord', 'U') IS NOT NULL
	DROP TABLE NoteBrowsedRecord
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'NoteBrowsedRecord')
--	DROP TABLE NoteBrowsedRecord

IF OBJECT_ID('CommentContent', 'U') IS NOT NULL
	DROP TABLE CommentContent
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'CommentContent')
--	DROP TABLE CommentContent

IF OBJECT_ID('NoteComment', 'U') IS NOT NULL
	DROP TABLE NoteComment
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'NoteComment')
--	DROP TABLE NoteComment

IF OBJECT_ID('NoteContent', 'U') IS NOT NULL
	DROP TABLE NoteContent
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'NoteContent')
--	DROP TABLE NoteContent

IF OBJECT_ID('Note', 'U') IS NOT NULL
	DROP TABLE Note
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Note')
--	DROP TABLE Note
	
IF OBJECT_ID('NoteUser', 'U') IS NOT NULL
	DROP TABLE NoteUser
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'NoteUser')
--	DROP TABLE NoteUser

IF OBJECT_ID('Verification', 'U') IS NOT NULL
	DROP TABLE Verification
--IF EXISTS(SELECT * FROM sysobjects WHERE name = 'Verification')
--	DROP TABLE Verification
GO

/**********************************************************/
/****************创建表FtpConfig***************************/
/**********************************************************/
CREATE TABLE SysInfo
(
Id INT IDENTITY(1, 1) NOT NULL,
Name VARCHAR(128) NOT NULL,
[Description] NVARCHAR(128) NOT NULL,
Detail NVARCHAR NOT NULL,
PRIMARY KEY(Id)
)
GO

/**********************************************************/
/****************创建表FtpConfig***************************/
/**********************************************************/
CREATE TABLE FtpConfig
(
Id INT IDENTITY(1, 1) NOT NULL,
Name NVARCHAR(128) NOT NULL UNIQUE,
[Description] NVARCHAR,
IP VARCHAR(15) NOT NULL,
Port INT,
IsNeedAuthentication BIT NOT NULL,
VirticalDir NVARCHAR(128) NOT NULL,
UserName NVARCHAR(128),
[Password] VARCHAR(128),
PRIMARY KEY(Id)
)
GO

/**********************************************************/
/****************创建表NoteUser****************************/
/**********************************************************/
--IF EXISTS (SELECT COUNT(*) FROM SYSOBJECTS WHERE ID = OBJECT_ID('MyNote.OWNER.Note'))
--	DROP TABLE Note
	
CREATE TABLE NoteUser
(
Id INT IDENTITY(1, 1) NOT NULL,
Name NVARCHAR(128) NOT NULL,
PhoneNumber VARCHAR(128) UNIQUE NOT NULL,
Email VARCHAR(128) UNIQUE,
ProfilePicture NVARCHAR(128) UNIQUE,
HashCode VARCHAR(128) NOT NULL,
Salt VARCHAR(128) NOT NULL,
CreateTime DATETIME NOT NULL,
LastLoginTime DATETIME NOT NULL,
LastLoginAddress VARCHAR(15) NOT NULL,
Token VARCHAR(128) NOT NULL,
VerificationCode VARCHAR(128),
PRIMARY KEY(Id)
)
GO

/**********************************************************/
/****************创建表Verification************************/
/**********************************************************/
CREATE TABLE Verification
(
Id INT IDENTITY(1, 1) NOT NULL,
PhoneNumber NVARCHAR(128) NOT NULL UNIQUE,
StartTime DATETIME NOT NULL,
Code VARCHAR(128) NOT NULL,
PRIMARY KEY(Id)
)
GO

/**********************************************************/
/****************创建表Note********************************/
/**********************************************************/
--IF EXISTS (SELECT COUNT(*) FROM SYSOBJECTS WHERE ID = OBJECT_ID('MyNote.OWNER.NoteUser'))
--	DROP TABLE NoteUser
	
CREATE TABLE Note
(
Id INT IDENTITY(1, 1) NOT NULL,
AuthorId INT NOT NULL,
Title NVARCHAR(128) NOT NULL,
Remark NVARCHAR(128),
CreateTime DATETIME NOT NULL,
LastBrowsedTime DATETIME NOT NULL,
IsShared BIT NOT NULL,
IsDeleted BIT NOT NULL,
DeletedTime DATETIME NOT NULL,
PRIMARY KEY(Id),
FOREIGN KEY(AuthorId) REFERENCES NoteUser(Id)
)

/**********************************************************/
/****************创建表NoteContent*************************/
/**********************************************************/

CREATE TABLE NoteContent
(
Id INT IDENTITY(1, 1) NOT NULL,
NoteId INT NOT NULL,
[Type] INT NOT NULL,
Content NVARCHAR(1024) NOT NULL,
CreateTime DATETIME NOT NULL,
IsDeleted BIT NOT NULL,
DeletedTime DATETIME NOT NULL,
PRIMARY KEY(Id),
FOREIGN KEY(NoteId) REFERENCES Note(Id)
)

/**********************************************************/
/****************创建表NoteComment*************************/
/**********************************************************/

CREATE TABLE NoteComment
(
Id INT IDENTITY(1, 1) NOT NULL,
NoteId INT NOT NULL,
CreatorId INT NOT NULL,
CommentId INT,
CreateTime DATETIME NOT NULL,
IsDeleted BIT NOT NULL,
DeletedTime DATETIME NOT NULL,
PRIMARY KEY(Id),
FOREIGN KEY(CreatorId) REFERENCES NoteUser(Id),
FOREIGN KEY(NoteId) REFERENCES Note(Id)
)

/**********************************************************/
/****************创建表CommentContent**********************/
/**********************************************************/
	
CREATE TABLE CommentContent
(
Id INT IDENTITY(1, 1) NOT NULL,
CommentId INT NOT NULL,
[Type] INT NOT NULL,
Content NVARCHAR NOT NULL,
CreateTime DATETIME NOT NULL,
PRIMARY KEY(Id),
FOREIGN KEY(CommentId) REFERENCES NoteComment(Id)
)

/**********************************************************/
/****************创建表NoteApprovedRecord******************/
/**********************************************************/
	
CREATE TABLE NoteApprovedRecord
(
Id INT IDENTITY(1, 1) NOT NULL,
UserId INT NOT NULL,
NoteId INT NOT NULL,
ApprovedTime DATETIME NOT NULL,
IsCanceled BIT NOT NULL,
CanceledTime DATETIME
PRIMARY KEY(Id),
FOREIGN KEY(UserId) REFERENCES NoteUser(Id),
FOREIGN KEY(NoteId) REFERENCES Note(Id)
)

/**********************************************************/
/****************创建表NoteBrowsedRecord*******************/
/**********************************************************/
CREATE TABLE NoteBrowsedRecord
(
Id INT IDENTITY(1, 1) NOT NULL,
UserId INT NOT NULL,
NoteId INT NOT NULL,
BrowsedTime DATETIME NOT NULL,
PRIMARY KEY(Id),
FOREIGN KEY(UserId) REFERENCES NoteUser(Id),
FOREIGN KEY(NoteId) REFERENCES Note(Id)
)