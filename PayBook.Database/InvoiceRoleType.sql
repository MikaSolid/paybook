CREATE TABLE [dbo].[InvoiceRoleType]
(
	[RoleTypeId] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_InvoiceRoleType_RoleType] FOREIGN KEY ([RoleTypeId]) REFERENCES [RoleType]([Id]) 
)
