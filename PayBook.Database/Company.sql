CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CompanyNumber] NVARCHAR(50) NULL, 
    [TaxNumber] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Company_Organization] FOREIGN KEY ([Id]) REFERENCES [Organization]([Id])
)
