USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ALBUM_TBL]    Script Date: 2016/1/31 23:15:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_ALBUM_TBL](
	[ALBUM_ID] [nchar](10) NOT NULL,
	[ALBUM_ANIME_TYPE] [char](1) NOT NULL,
	[ALBUM_INANIME_NO] [int] NULL,
	[ANIME_NO] [nchar](4) NOT NULL,
	[ALBUM_TYPE] [tinyint] NOT NULL,
	[ALBUM_TITLE_NAME] [char](1000) NOT NULL,
	[TOTAL_DISC_COUNT] [smallint] NOT NULL,
	[TOTAL_TRACK_COUNT] [smallint] NOT NULL,
	[DESCRIPTION] [nvarchar](1000) NULL,
	[ENABLE_FLG] [bit] NOT NULL DEFAULT ((1)),
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ALBUM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


