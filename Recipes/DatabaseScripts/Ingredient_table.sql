USE [Recipes]
GO

ALTER TABLE [dbo].[Ingredient] DROP CONSTRAINT [FK_ToRecipe]
GO

/****** Object:  Table [dbo].[Ingredient]    Script Date: 7/22/2014 8:49:20 PM ******/
DROP TABLE [dbo].[Ingredient]
GO

/****** Object:  Table [dbo].[Ingredient]    Script Date: 7/22/2014 8:49:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Ingredient](
	[IngredientsId] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[Ingredient] [varchar](512) NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[IngredientsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Ingredient]  WITH CHECK ADD  CONSTRAINT [FK_ToRecipe] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipe] ([RecipeId])
GO

ALTER TABLE [dbo].[Ingredient] CHECK CONSTRAINT [FK_ToRecipe]
GO

