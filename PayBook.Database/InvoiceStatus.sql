CREATE TABLE [dbo].[InvoiceStatus]
(
	[InvoiceId] INT NOT NULL PRIMARY KEY, 
    [InvoiceStatusTypeId] INT NOT NULL, 
    [StatusDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_InvoiceStatus_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice]([Id]), 
    CONSTRAINT [FK_InvoiceStatus_InvoiceStatusType] FOREIGN KEY ([InvoiceStatusTypeId]) REFERENCES [InvoiceStatusType]([Id])
)
