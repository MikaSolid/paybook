CREATE TABLE [dbo].[BillingAccountRole]
(
	[PartyId] INT NOT NULL PRIMARY KEY, 
    [BillingAccountId] INT NOT NULL, 
    [FromDate] DATETIME NULL, 
    [ToDate] DATETIME NULL, 
	CONSTRAINT [FK_BillingAccountRole_Party] FOREIGN KEY ([PartyId]) REFERENCES [Party]([Id]),
    CONSTRAINT [FK_BillingAccountRole_BillingAccount] FOREIGN KEY ([BillingAccountId]) REFERENCES [BillingAccount]([Id])
)
