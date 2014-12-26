CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PaymentMethodTypeId] INT NOT NULL, 
    [PartyIdFrom] INT NOT NULL, 
    [PartyIdTo] INT NOT NULL, 
    [EffectiveDate] DATETIME NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [Currency] INT NOT NULL, 
    [Comment] NVARCHAR(1000) NULL, 
    [PaymentTypeId] INT NOT NULL, 
    CONSTRAINT [FK_Payment_PaymentMethodType] FOREIGN KEY ([PaymentMethodTypeId]) REFERENCES [PaymentMethodType]([Id]), 
    CONSTRAINT [FK_Payment_PartyFrom] FOREIGN KEY ([PartyIdFrom]) REFERENCES [Party]([Id]), 
    CONSTRAINT [FK_Payment_PartyTo] FOREIGN KEY ([PartyIdTo]) REFERENCES [Party]([Id])
)
