USE [ANIMEDATA]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_ALBUM_ID_TBL_LAST_UPDATE_DATETIME]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ALBUM_ID_TBL] DROP CONSTRAINT [DF_T_ALBUM_ID_TBL_LAST_UPDATE_DATETIME]
END

GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ALBUM_ID_TBL]    Script Date: 08/02/2016 15:48:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ALBUM_ID_TBL]') AND type in (N'U'))
DROP TABLE [dbo].[T_ALBUM_ID_TBL]
GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ALBUM_ID_TBL]    Script Date: 08/02/2016 15:48:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_ALBUM_ID_TBL](
	[ALBUM_ID] [nchar](10) NOT NULL,
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL,
 CONSTRAINT [PK_T_ALBUM_ID_TBL] PRIMARY KEY CLUSTERED 
(
	[ALBUM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[T_ALBUM_ID_TBL] ADD  CONSTRAINT [DF_T_ALBUM_ID_TBL_LAST_UPDATE_DATETIME]  DEFAULT (getdate()) FOR [LAST_UPDATE_DATETIME]
GO


