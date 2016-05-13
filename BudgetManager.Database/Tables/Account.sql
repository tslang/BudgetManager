CREATE TABLE [BudgetManager].[Account] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NOT NULL,
    [Bank]   NVARCHAR (50) NOT NULL,
    [Amount] MONEY         NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC)
);

