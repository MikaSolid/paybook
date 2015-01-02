CREATE TABLE [dbo].[Phone]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Number] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Phone_ContactMechanism] FOREIGN KEY ([Id]) REFERENCES [ContactMechanism]([Id])
)
