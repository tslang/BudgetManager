CREATE TABLE [dbo].[Account]
(
	[Id]				INT					IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
	[Name]				NVARCHAR (50)		NOT NULL,
	[Bank]				NVARCHAR (50)		NOT NULL,
	[AccountTypeId]		INT					NOT NULL,
	[Amount]			MONEY				NOT NULL,
	CONSTRAINT [FK_AccountType_Id] FOREIGN KEY ([AccountTypeId]) REFERENCES [AccountType] ([Id]), 
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id])
)
