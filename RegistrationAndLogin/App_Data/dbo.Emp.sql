CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [JobTitle] NCHAR(10) NULL, 
    [Task] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [CK_Table_Column] CHECK (1 = 1) 
)
