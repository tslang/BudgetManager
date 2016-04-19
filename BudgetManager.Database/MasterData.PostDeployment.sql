/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF DATABASE_PRINCIPAL_ID('BudgetManagerApp') IS NULL
BEGIN
	CREATE ROLE [BudgetManagerApp]
END

GRANT SELECT ON SCHEMA :: [dbo] TO [BudgetManagerApp]
GRANT INSERT ON SCHEMA :: [dbo] TO [BudgetManagerApp]
GRANT UPDATE ON SCHEMA :: [dbo] TO [BudgetManagerApp]
GRANT DELETE ON SCHEMA :: [dbo] TO [BudgetManagerApp]
GRANT EXECUTE ON SCHEMA :: [dbo] TO [BudgetManagerApp]

DECLARE @ApplicationName NVARCHAR(30) = N'/BudgeManager'

------------------------------------------------
MERGE INTO [dbo].[Category] as Target
USING (VALUES
 (1, N'Mortgage'),
 (2, N'Utilities'),
 (3, N'Food & Drink')
 )
 AS Source (
	Id,
	Name)
ON Target.Id = Source.Id And
	Target.Name = Source.Name
-- update matched rows
 WHEN MATCHED THEN
 UPDATE SET Id = Source.Id,
 Name=Source.Name
 -- insert new rows
 WHEN NOT MATCHED BY TARGET THEN
 INSERT (
			[Id]
			,[Name])
VALUES
		(
		 Source.Id
		 ,Source.Name)
-- delete rows that are in the target but not in the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;
