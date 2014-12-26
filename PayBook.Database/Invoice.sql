CREATE TABLE [dbo].[Invoice]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PartyId] INT NOT NULL, 
    [RoleTypeId] INT NOT NULL, 
    [InvoiceDate] DATETIME NULL, 
    CONSTRAINT [FK_Invoice_Party] FOREIGN KEY ([PartyId]) REFERENCES [Party]([Id]), 
    CONSTRAINT [FK_Invoice_RoleType] FOREIGN KEY ([RoleTypeId]) REFERENCES [RoleType]([Id])
)
