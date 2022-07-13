CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(30) NULL, 
    [Email] VARCHAR(40) NULL, 
    [Password] VARCHAR(30) NULL, 
    [IsAdmin] VARCHAR(30) NULL, 
    [IsActive] BIT NULL, 
    [IsOnline] BIT NULL, 
    [imageURL] VARCHAR(2000) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
