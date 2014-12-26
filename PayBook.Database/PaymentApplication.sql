CREATE TABLE [dbo].[PaymentApplication]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AmountApplied] DECIMAL(18, 2) NOT NULL, 
    [BillingAccountId] INT NOT NULL, 
    [InvoiceId] INT NOT NULL
)
