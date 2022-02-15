USE [master]
GO

IF DB_ID('CicekSepetiCart') IS NOT NULL
  set noexec on               -- prevent creation when already exists

CREATE DATABASE [CicekSepetiCart];
GO

USE [CicekSepetiCart]
GO

CREATE TABLE [CartItems](
	[Id] [varchar](100) NOT NULL,
	[CreatedAt] [DateTime] NOT NULL,
	[ModifiedAt] [DateTime] NULL,
	[UserId] [varchar](100) NOT NULL,
	[ProductId] [varchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Status] [int]NOT NULL,
CONSTRAINT [PK_CartItems] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)) ON [PRIMARY]
GO
