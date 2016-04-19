CREATE TABLE [dbo].[Category]
(
	[Id]		INT				NOT NULL, 
    [Name]				NVARCHAR(50)	NOT NULL
	CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id])
)
