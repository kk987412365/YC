IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'YC')
	begin
		CREATE DATABASE YC; 
	end
Go

use YC
Go

IF NOT EXISTS( SELECT * FROM sys.tables WHERE name = 'VersionLog' )
	begin
		CREATE TABLE [dbo].[VersionLog](
			[SN] [int] IDENTITY(1,1) NOT NULL,
			[Version] [nvarchar](10) NOT NULL,
			[Description] [nvarchar](200) NULL,
		 CONSTRAINT [PK_VersionLog] PRIMARY KEY CLUSTERED 
		(
			[Version] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
	end
Go 
/*
Version 1.0 
Des:Create Costumer
*/
IF NOT EXISTS( SELECT * FROM VersionLog WHERE [Version] = 1.0)
	begin	
		CREATE TABLE [dbo].[Costumer](
			[SN] [int] IDENTITY(1,1) NOT NULL,
			[ID] [nvarchar](10) NOT NULL,
			[Name] [nvarchar](50) NOT NULL,
			[Age] [int] NOT NULL,
			[Email] [nvarchar](100) NOT NULL,
		 CONSTRAINT [PK_Costumer] PRIMARY KEY CLUSTERED 
		(
			[ID] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
		
		Insert Into VersionLog ([Version],[Description])values(1.0,'Create Costumer')
	end
Go 

