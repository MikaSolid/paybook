CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Comment] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Person_Party] FOREIGN KEY ([Id]) REFERENCES [Party]([Id])
)