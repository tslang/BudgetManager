CREATE TABLE [dbo].[Transaction]
(
	[Id]			INT				NOT NULL IDENTITY, 
    [Description]			NVARCHAR(MAX)	NULL, 
    [Amount]				MONEY			NOT NULL, 
    [CategoryId]			INT				NOT NULL,
	[AccountId]				INT				NOT NULL
	CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Transaction_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
	CONSTRAINT [FK_Transaction_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id])
)
