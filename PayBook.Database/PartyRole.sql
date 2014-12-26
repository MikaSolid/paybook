CREATE TABLE [dbo].[PartyRole]
(
    [PartyId] INT NOT NULL, 
    [RoleTypeId] INT NOT NULL, 
    CONSTRAINT [FK_PartyRole_Party] FOREIGN KEY ([PartyId]) REFERENCES [Party]([Id]), 
    CONSTRAINT [FK_PartyRole_RoleType] FOREIGN KEY ([RoleTypeId]) REFERENCES [RoleType]([Id]), 
    CONSTRAINT [PK_PartyRole] PRIMARY KEY ([PartyId])
)

GO
