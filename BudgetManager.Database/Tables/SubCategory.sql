CREATE TABLE [BudgetManager].[SubCategory] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [CategoryId] INT            NULL,
    CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SubCategory_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [BudgetManager].[Category] ([Id])
);

