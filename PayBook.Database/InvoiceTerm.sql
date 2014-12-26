CREATE TABLE [dbo].[InvoiceTerm]
(
	[InvoiceTermId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TermTypeId] INT NOT NULL, 
    [InvoiceId] INT NULL, 
    [InvoiceItemId] INT NULL, 
    [TermValue] DECIMAL(18, 2) NULL, 
    CONSTRAINT [FK_InvoiceTerm_InvoiceTermType] FOREIGN KEY ([TermTypeId]) REFERENCES [TermType]([Id]), 
    CONSTRAINT [FK_InvoiceTerm_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice]([Id]), 
    CONSTRAINT [FK_InvoiceTerm_InvoiceItem] FOREIGN KEY ([InvoiceItemId]) REFERENCES [InvoiceItem]([Id])
)
