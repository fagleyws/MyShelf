CREATE TABLE [dbo].[BookGenre] (
    [BookID]  INT NOT NULL,
    [GenreID] INT NOT NULL,
    CONSTRAINT [FK_BookGenre_Book] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Book] ([BookID]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookGenre_Genre] FOREIGN KEY ([GenreID]) REFERENCES [dbo].[Genre] ([GenreID]) ON DELETE CASCADE
);

