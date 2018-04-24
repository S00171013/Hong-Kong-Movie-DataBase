
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/24/2018 19:37:38
-- Generated from EDMX file: C:\Users\Jack\Source\Repos\Hong-Kong-Movie-DataBase\Hong Kong Movie DataBase\Hong Kong Movie DataBase\HKMovies.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HKFilms];
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

-- Creating table 'Films'
CREATE TABLE [dbo].[Films] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [ReleaseDate] datetime  NOT NULL,
    [Director] nvarchar(max)  NOT NULL,
    [RunningTime] nvarchar(max)  NOT NULL,
    [PosterImage] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Actors'
CREATE TABLE [dbo].[Actors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FilmActor'
CREATE TABLE [dbo].[FilmActor] (
    [Films_Id] int  NOT NULL,
    [Actors_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Films'
ALTER TABLE [dbo].[Films]
ADD CONSTRAINT [PK_Films]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Actors'
ALTER TABLE [dbo].[Actors]
ADD CONSTRAINT [PK_Actors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Films_Id], [Actors_Id] in table 'FilmActor'
ALTER TABLE [dbo].[FilmActor]
ADD CONSTRAINT [PK_FilmActor]
    PRIMARY KEY CLUSTERED ([Films_Id], [Actors_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Films_Id] in table 'FilmActor'
ALTER TABLE [dbo].[FilmActor]
ADD CONSTRAINT [FK_FilmActor_Film]
    FOREIGN KEY ([Films_Id])
    REFERENCES [dbo].[Films]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Actors_Id] in table 'FilmActor'
ALTER TABLE [dbo].[FilmActor]
ADD CONSTRAINT [FK_FilmActor_Actor]
    FOREIGN KEY ([Actors_Id])
    REFERENCES [dbo].[Actors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmActor_Actor'
CREATE INDEX [IX_FK_FilmActor_Actor]
ON [dbo].[FilmActor]
    ([Actors_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------