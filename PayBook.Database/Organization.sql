CREATE TABLE [dbo].[Organization]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(1000) NOT NULL, 
    CONSTRAINT [FK_Organization_Party] FOREIGN KEY ([Id]) REFERENCES [Party]([Id])
)
