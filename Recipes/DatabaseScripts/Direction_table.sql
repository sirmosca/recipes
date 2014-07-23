USE [Recipes]
GO

ALTER TABLE [dbo].[Direction] DROP CONSTRAINT [FK_ToDescription]
GO

/****** Object:  Table [dbo].[Direction]    Script Date: 7/22/2014 8:48:55 PM ******/
DROP TABLE [dbo].[Direction]
GO

/****** Object:  Table [dbo].[Direction]    Script Date: 7/22/2014 8:48:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Direction](
	[DirectionId] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Step] [int] NOT NULL,
 CONSTRAINT [PK_Step] PRIMARY KEY CLUSTERED 
(
	[DirectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Direction]  WITH CHECK ADD  CONSTRAINT [FK_ToDescription] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([RecipeId])
GO

ALTER TABLE [dbo].[Direction] CHECK CONSTRAINT [FK_ToDescription]
GO

