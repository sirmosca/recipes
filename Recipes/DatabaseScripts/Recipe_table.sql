USE [Recipes]
GO

/****** Object:  Table [dbo].[Recipe]    Script Date: 7/22/2014 8:49:31 PM ******/
DROP TABLE [dbo].[Recipe]
GO

/****** Object:  Table [dbo].[Recipe]    Script Date: 7/22/2014 8:49:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Recipe](
	[RecipeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Notes] [varchar](1024) NULL,
	[ServingSize] [varchar](50) NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

