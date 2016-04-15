CREATE TABLE [dbo].[Transaction]
(
	[Id]				INT				PRIMARY KEY IDENTITY NOT NULL,
	[Date]				DATETIME		DEFAULT (getdate()) NOT NULL,
	[Name]				NVARCHAR(255)	NULL,
	[Description]		NVARCHAR(255)	NOT NULL,
	[Amount]			MONEY			NOT NULL,
	[AccountId]			INT				NOT NULL,
	CONSTRAINT [FK_Account_AccountId] FOREIGN KEY ([Id]) REFERENCES [Account] ([Id])
)
