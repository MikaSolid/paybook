CREATE TABLE [dbo].[InvoiceItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InvoiceId] INT NOT NULL, 
    [Amount] DECIMAL(18, 2) NOT NULL, 
    [Description] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_InvoiceItem_Invoice] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoice]([Id])
)
