CREATE TABLE [dbo].[PartyContactMechanism]
(
	[Id] INT NOT NULL IDENTITY,
	[PartyId] INT NOT NULL , 
    [ContactMechanismId] INT NOT NULL, 
    [Comment] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_PartyContactMechanism_Party] FOREIGN KEY ([PartyId]) REFERENCES [Party]([Id]), 
    CONSTRAINT [FK_PartyContactMechanism_ContactMechanism] FOREIGN KEY ([ContactMechanismId]) REFERENCES [ContactMechanism]([Id]), 
    CONSTRAINT [PK_PartyContactMechanism] PRIMARY KEY ([Id])
)
