CREATE TABLE [dbo].[Version] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [versionName]            NVARCHAR (255) NOT NULL,
    [help]                   VARCHAR (8000) NULL,
    [path]                   NVARCHAR (255) NOT NULL,
    [fullName]               NVARCHAR (255) NOT NULL,
    [canonicalVersionString] NVARCHAR (255) NOT NULL,
    [PackageId]              INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PackageId]) REFERENCES [dbo].[Package] ([Id])
);

CREATE TABLE [dbo].[Package] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [package]            NVARCHAR (255) NOT NULL,
    [categories]         NVARCHAR (255) NOT NULL,
    [url]                NVARCHAR (255) NOT NULL,
    [displayName]        NVARCHAR (255) NULL,
    [description]        VARCHAR (8000) NOT NULL,
    [defaultVersionName] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
