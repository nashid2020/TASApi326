CREATE DATABASE TestDB;
GO
USE DATABASE;
GO
CREATE TABLE [dbo].[Package] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ShortName]   NVARCHAR (255) NOT NULL,
    [LongName]    NVARCHAR (255) NULL,
    [Description] VARCHAR (8000) NULL,
    [Url]         NVARCHAR (255) NULL,
    [TopicId]     INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TopicId]) REFERENCES [dbo].[Topic] ([Id])
);
GO
CREATE TABLE [dbo].[Versions] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Description] VARCHAR (8000) NULL,
    [PackageId]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([PackageId]) REFERENCES [dbo].[Package] ([Id])
);
GO
CREATE TABLE [dbo].[MachineVersions] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [IsDefault]        BIT            NOT NULL,
    [Documentation]    VARCHAR (8000) NULL,
    [CanonicalVersion] NVARCHAR (50)  NULL,
    [MachineId]        INT            NOT NULL,
    [VersionsId]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([MachineId]) REFERENCES [dbo].[Machine] ([Id]),
    FOREIGN KEY ([VersionsId]) REFERENCES [dbo].[Versions] ([Id])
);
GO
CREATE TABLE [dbo].[Machine] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [dbo].[MachineVersionsModulePath] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [MachineVersionsId] INT NOT NULL,
    [ModulePathId]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([MachineVersionsId]) REFERENCES [dbo].[MachineVersions] ([Id]),
    FOREIGN KEY ([ModulePathId]) REFERENCES [dbo].[ModulePath] ([Id])
);
GO
CREATE TABLE [dbo].[ModulePath] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Value] NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE TABLE [dbo].[Topic] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
