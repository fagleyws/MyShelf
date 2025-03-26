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
SET IDENTITY_INSERT [dbo].[User] OFF
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
INSERT [dbo].[Publisher] ([PublisherID], [PublishName], [PublisherProfileImage], [PublisherDescription], [PublisherAddress], [PublisherWebsite], [PublisherPhone]) VALUES (1, N'Random House Worlds', NULL, N'Random House Worlds', NULL, NULL, NULL)
GO
INSERT [dbo].[Publisher] ([PublisherID], [PublishName], [PublisherProfileImage], [PublisherDescription], [PublisherAddress], [PublisherWebsite], [PublisherPhone]) VALUES (2, N'Berkley Books', N'', N'Berkley Books is an American imprint founded in 1955 by Charles Byrne and Frederic Klein owned by the Penguin Group unit of Penguin Random House.', NULL, NULL, NULL)
GO
INSERT [dbo].[Publisher] ([PublisherID], [PublishName], [PublisherProfileImage], [PublisherDescription], [PublisherAddress], [PublisherWebsite], [PublisherPhone]) VALUES (3, N'Simon & Schuster Books', NULL, N'Simon & Schuster LLC is an American publishing house owned by Kohlberg Kravis Roberts since 2023.', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (1, N'Action')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (2, N'Fiction')
GO
INSERT [dbo].[Genre] ([GenreID], [GenreName]) VALUES (3, N'Romance')
GO