CREATE TABLE [dbo].[Tache]
(
	[Id] INT NOT NULL IDENTITY, 
    [Titre] NVARCHAR(255) NOT NULL, 
    [Creation] DATETIME2 NOT NULL
        CONSTRAINT DF_Tache_Creation DEFAULT (SYSDATETIME()), 
    [Termine] BIT NOT NULL
        CONSTRAINT DF_Tache_Termine DEFAULT (0), 
    CONSTRAINT [PK_Tache] PRIMARY KEY ([Id]) 
)
