CREATE TABLE [dbo].[Supplier]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_Supplier_Party] FOREIGN KEY ([Id]) REFERENCES [Organization]([Id])
)
