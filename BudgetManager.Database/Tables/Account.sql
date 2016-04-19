CREATE TABLE [dbo].[Account]
(
	[Id]			INT					NOT NULL	IDENTITY, 
    [Name]			NVARCHAR(50)		NOT NULL,
	[Bank]			NVARCHAR(50)		NOT NULL, 
    [Amount]		MONEY				NOT NULL,
	CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id])
)
