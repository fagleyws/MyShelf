CREATE TABLE [dbo].[Genre] (
    [GenreID]   INT           NOT NULL,
    [GenreName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED ([GenreID] ASC)
);

