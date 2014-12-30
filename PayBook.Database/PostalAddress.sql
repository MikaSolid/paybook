CREATE TABLE [dbo].[PostalAddress]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Address1] NVARCHAR(200) NULL, 
    [Address2] NCHAR(200) NULL, 
    [City] NVARCHAR(100) NULL, 
    [ZipCode] NVARCHAR(20) NULL, 
    [State] NVARCHAR(50) NULL, 
    [Country] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_PostalAddress_ContactMechanism] FOREIGN KEY ([Id]) REFERENCES [ContactMechanism]([Id])
)
