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
NAME = 'mynote_data', --�������ļ����߼���
FILENAME = 'F:\SQL Server 2008\MyNote\mynote_data.mdf', --�������ļ���������
SIZE = 5MB, --�������ļ���ʼ��С
MAXSIZE = 100MB, --�������ļ����������ֵ
FILEGROWTH = 15% --�������ļ���������
)
LOG ON
(
NAME = 'mynote_log',
FILENAME = 'F:\SQL Server 2008\MyNote\mynote_log.ldf',
SIZE = 2MB,
FILEGROWTH = 1MB
)
GO