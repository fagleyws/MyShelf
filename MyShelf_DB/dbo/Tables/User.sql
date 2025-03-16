CREATE TABLE [dbo].[User] (
    [UserID]           INT           IDENTITY (1, 1) NOT NULL,
    [UserFirstName]    NVARCHAR (50) NOT NULL,
    [UserLastName]     NVARCHAR (50) NOT NULL,
    [UserProfileImage] VARCHAR (200) NOT NULL,
    [UserPassword]     VARCHAR (100) NOT NULL,
    [LastLoginTime]    DATETIME      NULL,
    [AccountTypeID]    INT           NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_User_AccountType] FOREIGN KEY ([AccountTypeID]) REFERENCES [dbo].[AccountType] ([AccountTypeID]) ON DELETE CASCADE
);

