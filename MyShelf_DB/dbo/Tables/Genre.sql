CREATE TABLE [dbo].[Genre] (
    [GenreID]   INT           IDENTITY (1, 1) NOT NULL,
    [GenreName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED ([GenreID] ASC)
);

