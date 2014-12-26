CREATE TABLE [dbo].[InvoiceRole]
(
    [PartyId] INT NOT NULL, 
    [InvoiceId] INT NOT NULL, 
    [RoleTypeId] INT NOT NULL, 
    [Datetime] DATETIME NULL, 
    CONSTRAINT [FK_InvoiceRole_Party] FOREIGN KEY ([PartyId]) REFERENCES [Party]([Id]), 
    CONSTRAINT [FK_InvoiceRole_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice]([Id]), 
    CONSTRAINT [FK_InvoiceRole_RoleType] FOREIGN KEY ([RoleTypeId]) REFERENCES [InvoiceRoleType]([RoleTypeId])
)
