CREATE TABLE [BudgetManager].[Transaction] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [Amount]        MONEY          NOT NULL,
    [AccountId]     INT            NOT NULL,
    [CategoryId]    INT            NOT NULL,
    [SubCategoryId] INT            NOT NULL,
    CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transaction_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [BudgetManager].[Account] ([Id]),
    CONSTRAINT [FK_Transaction_SubCategoryId] FOREIGN KEY ([SubCategoryId]) REFERENCES [BudgetManager].[SubCategory] ([Id]),
    CONSTRAINT [FK_Transaction_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [BudgetManager].[Category] ([Id])
);

