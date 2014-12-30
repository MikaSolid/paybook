CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    CONSTRAINT [FK_Company_Party] FOREIGN KEY ([Id]) REFERENCES [Organization]([Id])
)
