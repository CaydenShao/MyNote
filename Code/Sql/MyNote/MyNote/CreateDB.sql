USE master
GO

IF DB_ID('MyNote') IS NOT NULL
	DROP DATABASE MyNote
--IF EXISTS(SELECT * FROM sysdatabases WHERE name = 'MyNote')
--	DROP DATABASE MyNote
GO

CREATE DATABASE MyNote
	ON PRIMARY
(
NAME = 'mynote_data', --主数据文件的逻辑名
FILENAME = 'F:\SQL Server 2008\MyNote\mynote_data.mdf', --主数据文件的物理名
SIZE = 5MB, --主数据文件初始大小
MAXSIZE = 100MB, --主数据文件增长的最大值
FILEGROWTH = 15% --主数据文件的增长率
)
LOG ON
(
NAME = 'mynote_log',
FILENAME = 'F:\SQL Server 2008\MyNote\mynote_log.ldf',
SIZE = 2MB,
FILEGROWTH = 1MB
)
GO