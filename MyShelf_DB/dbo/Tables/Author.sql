CREATE TABLE [dbo].[Author] (
    [AuthorID]           INT             IDENTITY (1, 1) NOT NULL,
    [AuthorFirstName]    NVARCHAR (50)   NOT NULL,
    [AuthorLastName]     NVARCHAR (50)   NOT NULL,
    [AuthorProfileImage] NVARCHAR (500)  NULL,
    [AuthorDescription]  NVARCHAR (2500) NULL,
    [AuthorWebsite]      NVARCHAR (500)  NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([AuthorID] ASC)
);

