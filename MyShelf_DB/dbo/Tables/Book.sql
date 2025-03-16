CREATE TABLE [dbo].[Book] (
    [BookID]         INT             IDENTITY (1, 1) NOT NULL,
    [BookTitle]      NVARCHAR (200)  NOT NULL,
    [BookSummary]    NVARCHAR (2500) NOT NULL,
    [BookCoverImage] NVARCHAR (500)  NULL,
    [Price]          DECIMAL (12, 2) NOT NULL,
    [PageCount]      INT             NOT NULL,
    [ISBN13]         NVARCHAR (25)   NOT NULL,
    [AuthorID]       INT             NOT NULL,
    [PublisherID]    INT             NOT NULL,
    [LanguageID]     INT             NOT NULL,
    [FormatID]       INT             NOT NULL,
    [AddedBy]        INT             NULL,
    [DateAdded]      DATETIME        NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([BookID] ASC),
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Author] ([AuthorID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Book_Book] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Book] ([BookID]),
    CONSTRAINT [FK_Book_Format] FOREIGN KEY ([FormatID]) REFERENCES [dbo].[Format] ([FormatID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Book_Language] FOREIGN KEY ([LanguageID]) REFERENCES [dbo].[Language] ([LanguageID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Book_Publisher] FOREIGN KEY ([PublisherID]) REFERENCES [dbo].[Publisher] ([PublisherID]) ON DELETE CASCADE
);

