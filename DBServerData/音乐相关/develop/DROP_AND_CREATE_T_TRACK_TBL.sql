USE [ANIMEDATA_DEV]
GO

/****** Object:  Table [dbo].[T_TRACK_TBL]    Script Date: 2016/2/1 23:17:05 ******/
DROP TABLE [dbo].[T_TRACK_TBL]
GO

/****** Object:  Table [dbo].[T_TRACK_TBL]    Script Date: 2016/2/1 23:17:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_TRACK_TBL](
	[TRACK_ID] [nchar](10) NOT NULL,
	[P_ALBUM_ID] [nchar](10) NULL,
	[TRACK_TYPE_ID] [smallint] NOT NULL,
	[DISC_NO] [smallint] NOT NULL DEFAULT ((1)),
	[TRACK_NO] [smallint] NOT NULL,
	[TRACK_TITLE_NAME] [nvarchar](1000) NULL,
	[ARTIST_ID] [int] NOT NULL,
	[ANIME_NO] [nchar](4) NULL,
	[SALES_YEAR] [int] NULL,
	[DESCRIPTION] [nvarchar](1000) NULL,
	[ENABLE_FLG] [bit] NOT NULL DEFAULT ((1)),
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[TRACK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


