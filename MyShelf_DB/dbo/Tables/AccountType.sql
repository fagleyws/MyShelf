CREATE TABLE [dbo].[AccountType] (
    [AccountTypeID]   INT           NOT NULL,
    [AccountTypeName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED ([AccountTypeID] ASC)
);

