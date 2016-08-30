

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


USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ALBUM_TBL]    Script Date: 2016/2/1 23:14:12 ******/
DROP TABLE [dbo].[T_ALBUM_TBL]
GO

/****** Object:  Table [dbo].[T_ALBUM_TBL]    Script Date: 2016/2/1 23:14:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_ALBUM_TBL](
	[ALBUM_ID] [nchar](10) NOT NULL,
	[ALBUM_TYPE_ID] [int] NOT NULL,
	[ALBUM_INANIME_NO] [int] NULL,
	[ANIME_NO] [nchar](4) NULL,
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


USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ARTIST_ID_TBL]    Script Date: 08/05/2016 15:38:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ARTIST_ID_TBL]') AND type in (N'U'))
DROP TABLE [dbo].[T_ARTIST_ID_TBL]
GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ARTIST_ID_TBL]    Script Date: 08/05/2016 15:38:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_ARTIST_ID_TBL](
	[ARTIST_ID] [int] IDENTITY(1,1) NOT NULL,
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL,
 CONSTRAINT [PK_T_ARTIST_ID_TBL] PRIMARY KEY CLUSTERED 
(
	[ARTIST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [ANIMEDATA]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__T_ARTIST___ENABL__2EDAF651]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ARTIST_MAPPING_TBL] DROP CONSTRAINT [DF__T_ARTIST___ENABL__2EDAF651]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__T_ARTIST___LAST___2FCF1A8A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_ARTIST_MAPPING_TBL] DROP CONSTRAINT [DF__T_ARTIST___LAST___2FCF1A8A]
END

GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ARTIST_MAPPING_TBL]    Script Date: 02/26/2016 11:08:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_ARTIST_MAPPING_TBL]') AND type in (N'U'))
DROP TABLE [dbo].[T_ARTIST_MAPPING_TBL]
GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ARTIST_MAPPING_TBL]    Script Date: 02/26/2016 11:08:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_ARTIST_MAPPING_TBL](
	[ARTIST_ID] [nchar](10) NOT NULL,
	[MAPPING_TYPE] [tinyint] NOT NULL,
	[CHILD_CHARACTER_NO] [varchar](10) NULL,
	[CHILD_CV_ID] [int] NULL,
	[CHILD_ARTIST_ID] [int] NULL,
	[ENABLE_FLG] [bit] NOT NULL,
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[T_ARTIST_MAPPING_TBL] ADD  DEFAULT ((1)) FOR [ENABLE_FLG]
GO

ALTER TABLE [dbo].[T_ARTIST_MAPPING_TBL] ADD  DEFAULT (getdate()) FOR [LAST_UPDATE_DATETIME]
GO


USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_ARTIST_TBL]    Script Date: 2016/2/1 23:14:54 ******/
DROP TABLE [dbo].[T_ARTIST_TBL]
GO

/****** Object:  Table [dbo].[T_ARTIST_TBL]    Script Date: 2016/2/1 23:14:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_ARTIST_TBL](
	[ARTIST_ID] [int] NOT NULL,
	[ARTIST_NAME] [nvarchar](1000) NOT NULL,
	[GENDER_ID] [tinyint] NOT NULL,
	[CHARACTER_FLG] [bit] NOT NULL DEFAULT ((0)),
	[CV_FLG] [bit] NOT NULL DEFAULT ((0)),
	[SINGER_FLG] [bit] NOT NULL DEFAULT ((0)),
	[DESCRIPTION] [nvarchar](1000) NULL,
	[ENABLE_FLG] [bit] NOT NULL DEFAULT ((1)),
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[ARTIST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [ANIMEDATA]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_RESOURCE_ID_TBL_LAST_UDPATE_DATETIME]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_RESOURCE_ID_TBL] DROP CONSTRAINT [DF_T_RESOURCE_ID_TBL_LAST_UDPATE_DATETIME]
END

GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_RESOURCE_ID_TBL]    Script Date: 08/29/2016 10:23:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_RESOURCE_ID_TBL]') AND type in (N'U'))
DROP TABLE [dbo].[T_RESOURCE_ID_TBL]
GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_RESOURCE_ID_TBL]    Script Date: 08/29/2016 10:23:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_RESOURCE_ID_TBL](
	[RESOURCE_ID] [int] IDENTITY(1,1) NOT NULL,
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[T_RESOURCE_ID_TBL] ADD  CONSTRAINT [DF_T_RESOURCE_ID_TBL_LAST_UDPATE_DATETIME]  DEFAULT (getdate()) FOR [LAST_UDPATE_DATETIME]
GO


USE [ANIMEDATA]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__T_RESOURC__RESOU__0B27A5C0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_RESOURCE_TBL] DROP CONSTRAINT [DF__T_RESOURC__RESOU__0B27A5C0]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__T_RESOURC__ENABL__0C1BC9F9]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_RESOURCE_TBL] DROP CONSTRAINT [DF__T_RESOURC__ENABL__0C1BC9F9]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__T_RESOURC__LAST___0D0FEE32]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_RESOURCE_TBL] DROP CONSTRAINT [DF__T_RESOURC__LAST___0D0FEE32]
END

GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_RESOURCE_TBL]    Script Date: 08/23/2016 10:54:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_RESOURCE_TBL]') AND type in (N'U'))
DROP TABLE [dbo].[T_RESOURCE_TBL]
GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_RESOURCE_TBL]    Script Date: 08/23/2016 10:54:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_RESOURCE_TBL](
	[RESOURCE_ID] [int] NOT NULL,
	[RESOURCE_TYPE_ID] [tinyint] NOT NULL,
	[STORAGE_ID] [tinyint] NOT NULL,
	[RESOURCE_FILEPATH] [nvarchar](1000) NULL,
	[RESOURCE_FILENAME] [nvarchar](1000) NOT NULL,
	[RESOURCE_SUFFIX] [nvarchar](10) NOT NULL,
	[TRACK_BITRATE] [nvarchar](20) NULL,
	[TRACK_LENGTH] [int] NULL,
	[ENABLE_FLG] [bit] NOT NULL,
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RESOURCE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[T_RESOURCE_TBL] ADD  DEFAULT ((1)) FOR [RESOURCE_TYPE_ID]
GO

ALTER TABLE [dbo].[T_RESOURCE_TBL] ADD  DEFAULT ((1)) FOR [ENABLE_FLG]
GO

ALTER TABLE [dbo].[T_RESOURCE_TBL] ADD  DEFAULT (getdate()) FOR [LAST_UPDATE_DATETIME]
GO


USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_STORAGE_MST]    Script Date: 2016/2/1 23:16:39 ******/
DROP TABLE [dbo].[T_STORAGE_MST]
GO

/****** Object:  Table [dbo].[T_STORAGE_MST]    Script Date: 2016/2/1 23:16:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_STORAGE_MST](
	[STORAGE_ID] [int] NOT NULL,
	[STORAGE_PATH] [nvarchar](1000) NULL,
	[DESCRTITION] [nvarchar](1000) NULL,
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[STORAGE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


USE [ANIMEDATA]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_T_TRACK_ID_TBL_LAST_UPDATE_DATETIME]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[T_TRACK_ID_TBL] DROP CONSTRAINT [DF_T_TRACK_ID_TBL_LAST_UPDATE_DATETIME]
END

GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_TRACK_ID_TBL]    Script Date: 08/02/2016 15:50:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_TRACK_ID_TBL]') AND type in (N'U'))
DROP TABLE [dbo].[T_TRACK_ID_TBL]
GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_TRACK_ID_TBL]    Script Date: 08/02/2016 15:50:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[T_TRACK_ID_TBL](
	[TRACK_ID] [nchar](10) NOT NULL,
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL,
 CONSTRAINT [PK_T_TRACK_ID_TBL] PRIMARY KEY CLUSTERED 
(
	[TRACK_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[T_TRACK_ID_TBL] ADD  CONSTRAINT [DF_T_TRACK_ID_TBL_LAST_UPDATE_DATETIME]  DEFAULT (getdate()) FOR [LAST_UPDATE_DATETIME]
GO


USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_TRACK_RESOURCE_TBL]    Script Date: 02/26/2016 14:18:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_TRACK_RESOURCE_TBL]') AND type in (N'U'))
DROP TABLE [dbo].[T_TRACK_RESOURCE_TBL]
GO

USE [ANIMEDATA]
GO

/****** Object:  Table [dbo].[T_TRACK_RESOURCE_TBL]    Script Date: 02/26/2016 14:18:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[T_TRACK_RESOURCE_TBL](
	[TRACK_ID] [char](10) NOT NULL,
	[RESOURCE_ID] [int] NOT NULL,
	[ENABLE_FLG] [bit] NOT NULL,
	[LAST_UPDATE_DATETIME] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TRACK_ID] ASC,
	[RESOURCE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[T_TRACK_RESOURCE_TBL] ADD  DEFAULT ((1)) FOR [ENABLE_FLG]
GO

ALTER TABLE [dbo].[T_TRACK_RESOURCE_TBL] ADD  DEFAULT (getdate()) FOR [LAST_UPDATE_DATETIME]
GO


USE [ANIMEDATA]
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
	[ARTIST_ID] [nchar](10) NOT NULL,
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


