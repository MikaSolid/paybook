CREATE TABLE [dbo].[BillingAccount]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FromDate] DATETIME NULL, 
    [ToDate] DATETIME NULL, 
    [Description] NVARCHAR(100) NULL
)
