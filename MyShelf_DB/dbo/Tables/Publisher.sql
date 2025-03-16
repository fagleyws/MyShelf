CREATE TABLE [dbo].[Publisher] (
    [PublisherID]           INT             IDENTITY (1, 1) NOT NULL,
    [PublishName]           NVARCHAR (250)  NOT NULL,
    [PublisherProfileImage] VARCHAR (250)   NULL,
    [PublisherDescription]  NVARCHAR (2500) NULL,
    [PublisherAddress]      NVARCHAR (200)  NULL,
    [PublisherWebsite]      VARCHAR (500)   NULL,
    [PublisherPhone]        VARCHAR (20)    NULL,
    CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED ([PublisherID] ASC)
);

