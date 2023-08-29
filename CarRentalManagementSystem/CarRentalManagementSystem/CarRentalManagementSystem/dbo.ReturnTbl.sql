CREATE TABLE [dbo].[ReturnTbl] (
    [ReturnId]   INT           NOT NULL,
    [CarReg]     NVARCHAR (50) NOT NULL,
    [CustName]   NVARCHAR (50) NOT NULL,
    [ReturnDate] NVARCHAR (50) NOT NULL,
	[Delay] NVARCHAR (50) NOT NULL,
    [Fine]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([ReturnId] ASC)
);

