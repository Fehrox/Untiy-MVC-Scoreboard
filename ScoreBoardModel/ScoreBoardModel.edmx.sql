
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/15/2014 16:06:40
-- Generated from EDMX file: D:\Projects\ScoreBoard\ScoreBoard\ScoreBoardModel\ScoreBoardModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ScoreBoard];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Boards'
CREATE TABLE [dbo].[Boards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GameName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Scores'
CREATE TABLE [dbo].[Scores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BoardId] int  NOT NULL,
    [PlayerName] nvarchar(max)  NOT NULL,
    [Points] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Boards'
ALTER TABLE [dbo].[Boards]
ADD CONSTRAINT [PK_Boards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Scores'
ALTER TABLE [dbo].[Scores]
ADD CONSTRAINT [PK_Scores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BoardId] in table 'Scores'
ALTER TABLE [dbo].[Scores]
ADD CONSTRAINT [FK_BoardScore]
    FOREIGN KEY ([BoardId])
    REFERENCES [dbo].[Boards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BoardScore'
CREATE INDEX [IX_FK_BoardScore]
ON [dbo].[Scores]
    ([BoardId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------