/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName]) VALUES (2, N'Editor')
GO
INSERT [dbo].[AccountType] ([AccountTypeID], [AccountTypeName]) VALUES (3, N'RegularUser')
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserID], [UserFirstName], [UserLastName], [UserProfileImage], [UserEmail], [UserPassword], [LastLoginTime], [AccountTypeID]) VALUES (1, N'John', N'Doe', N'default.jpg', N'john.doe@sfasu.edu', N'123456', NULL, 3)
GO
INSERT [dbo].[User] ([UserID], [UserFirstName], [UserLastName], [UserProfileImage], [UserEmail], [UserPassword], [LastLoginTime], [AccountTypeID]) VALUES (2, N'Jane', N'Doe', N'default.jpg', N'jane.doe@sfasu.edu', N'1234567', NULL, 3)
GO
INSERT [dbo].[User] ([UserID], [UserFirstName], [UserLastName], [UserProfileImage], [UserEmail], [UserPassword], [LastLoginTime], [AccountTypeID]) VALUES (3, N'Jane', N'Doe', N'default.jpg', N'jane.doe@sfasu.edu', N'1234', NULL, 3)
GO
INSERT [dbo].[User] ([UserID], [UserFirstName], [UserLastName], [UserProfileImage], [UserEmail], [UserPassword], [LastLoginTime], [AccountTypeID]) VALUES (1002, N'Jeffrey', N'Zheng', N'default.jpg', N'jeffrey.zheng@sfasu.edu', N'$2a$11$puZ62KZu/hR8rmScye.22ee5qTTD8jBwpfamZzZAeBUyG4prrtCCm', CAST(N'2025-04-02T15:38:10.920' AS DateTime), 3)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Author] ON 
GO
INSERT [dbo].[Author] ([AuthorID], [AuthorFirstName], [AuthorLastName], [AuthorProfileImage], [AuthorDescription], [AuthorWebsite]) VALUES (1, N'John', N'Shekleton', N'https://www.goodreads.com/photo/author/5054023.John_Shekleton', N'John Shekleton is a writer living in Minneapolis. He is a former member of the Jesuits, a Catholic religious order. This committed society of men introduced him to the wonders of philosophy and allowed him to engage deeply with the world.', N'https://johnshekletonauthor.com/')
GO
INSERT [dbo].[Author] ([AuthorID], [AuthorFirstName], [AuthorLastName], [AuthorProfileImage], [AuthorDescription], [AuthorWebsite]) VALUES (2, N'John', N'Clay', N'https://images.gr-assets.com/authors/1738056326p5/54138131.jpg', N'John D. Clay Lost in the dark forest, I followed the distant sound of my own voice calling for help. When I reached the source, there was nothing but a shadowy figure grinning in the darkness.', NULL)
GO
INSERT [dbo].[Author] ([AuthorID], [AuthorFirstName], [AuthorLastName], [AuthorProfileImage], [AuthorDescription], [AuthorWebsite]) VALUES (3, N'Chip', N'Walter', N'https://images.gr-assets.com/authors/1548106327p5/81761.jpg', N'I am an author, National Geographic Explorer, filmmaker and former CNN bureau chief. Mostly because of my irrational curiosity, I''ve developed an unusually broad background that spans both science and entertainment. I have written and sold multiple screenplays, but my sixth book, Doppelgänger, is my first novel, a science fiction thriller that explores a post-dystopian world where the main character is faced with solving his own murder, and where artificial intelligence approaches human consciousness.', N'http://www.chipwalter.com/')
GO
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
INSERT [dbo].[Format] ([FormatID], [FormatName]) VALUES (1, N'Paperback')
GO
INSERT [dbo].[Format] ([FormatID], [FormatName]) VALUES (2, N'Hardcover')
GO
INSERT [dbo].[Format] ([FormatID], [FormatName]) VALUES (3, N'Kindle')
GO
INSERT [dbo].[Language] ([LanguageID], [LanguageName]) VALUES (1, N'English')
GO
INSERT [dbo].[Language] ([LanguageID], [LanguageName]) VALUES (2, N'French')
GO
INSERT [dbo].[Language] ([LanguageID], [LanguageName]) VALUES (3, N'German')
GO
INSERT [dbo].[Language] ([LanguageID], [LanguageName]) VALUES (4, N'Russian')
GO
INSERT [dbo].[Language] ([LanguageID], [LanguageName]) VALUES (5, N'Spanish')
GO
INSERT [dbo].[Language] ([LanguageID], [LanguageName]) VALUES (6, N'Chinese')
GO
INSERT [dbo].[Language] ([LanguageID], [LanguageName]) VALUES (7, N'Korean')
GO
INSERT [dbo].[Language] ([LanguageID], [LanguageName]) VALUES (8, N'Japanese')
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 
GO
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [PublisherProfileImage], [PublisherDescription], [PublisherAddress], [PublisherWebsite], [PublisherPhone]) VALUES (1, N'Random House Worlds', NULL, N'Random House Worlds', NULL, NULL, NULL)
GO
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [PublisherProfileImage], [PublisherDescription], [PublisherAddress], [PublisherWebsite], [PublisherPhone]) VALUES (2, N'Berkley Books', N'', N'Berkley Books is an American imprint founded in 1955 by Charles Byrne and Frederic Klein owned by the Penguin Group unit of Penguin Random House.', NULL, NULL, NULL)
GO
INSERT [dbo].[Publisher] ([PublisherID], [PublisherName], [PublisherProfileImage], [PublisherDescription], [PublisherAddress], [PublisherWebsite], [PublisherPhone]) VALUES (3, N'Simon & Schuster Books', NULL, N'Simon & Schuster LLC is an American publishing house owned by Kohlberg Kravis Roberts since 2023.', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 
GO
INSERT [dbo].[Book] ([BookID], [BookTitle], [BookSummary], [BookCoverImage], [Price], [PageCount], [ISBN13], [AuthorID], [PublisherID], [LanguageID], [FormatID], [AddedBy], [DateAdded]) VALUES (1002, N'The Once and Future Me', N'Virginia, 1954. When a young woman awakes on a transport bus arriving at Hanover State Psychiatric Hospital, she remembers nothing of her life before that moment, none of the dark things she must''ve seen—and done—to have forged her into such a cunning and skillful fighter. Dr. Sherman tells her she''s Dorothy Frasier, a paranoid schizophrenic committed by the state for her violent and grandiose delusions. But her gut and the steely voice inside her head make her certain he''s wrong—until unsettling visions begin to invade her reality, presenting her with a broken future where frantic scientists urge her to complete her mission in ''54: save humankind by finding a key to a cure for a deadly virus they call "The Guest."', N'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1727628990i/217387959.jpg', CAST(14.99 AS Decimal(12, 2)), 384, N'9781250358677', 1, 1, 1, 2, 1002, CAST(N'2025-04-09T15:09:38.017' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (1, N'Action')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (2, N'Fiction')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (3, N'Romance')
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (1002, 1)
GO
INSERT [dbo].[BookGenre] ([BookID], [GenreID]) VALUES (1002, 2)
GO
