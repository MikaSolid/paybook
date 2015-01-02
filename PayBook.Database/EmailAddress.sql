CREATE TABLE [dbo].[EmailAddress]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Address] NVARCHAR(255) NULL, 
    CONSTRAINT [FK_EmailAddress_ContactMechanism] FOREIGN KEY ([Id]) REFERENCES [ContactMechanism]([Id])
)
