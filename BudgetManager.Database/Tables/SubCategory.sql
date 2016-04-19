CREATE TABLE [dbo].[SubCategory]
(
	[Id]			INT				NOT NULL, 
    [Name]			NVARCHAR(50)	NOT NULL, 
    [CategoryId]	INT				NOT NULL
	CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_SubCategory_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
)
