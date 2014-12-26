CREATE TABLE [dbo].[BillingAccountRoleType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_BillingAccountRoleType_RoleType] FOREIGN KEY ([Id]) REFERENCES [RoleType]([Id])
)