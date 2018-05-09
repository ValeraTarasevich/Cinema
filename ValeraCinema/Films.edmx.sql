
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/10/2018 00:22:26
-- Generated from EDMX file: d:\Univer\6_term\Тестирование и отладка ПО\ValeraCinema\ValeraCinema\Films.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [cinema];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FilmOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_FilmOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_UserOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_UserOrder];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Films1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Films1];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Films1'
CREATE TABLE [dbo].[Films1] (
    [IdFilm] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Year] int  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Style] nvarchar(max)  NOT NULL,
    [Rating] float  NOT NULL,
    [Price] float  NOT NULL,
    [StartRental] datetime  NOT NULL,
    [FinishRental] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [IdUser] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL,
    [Nickname] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [IdOrder] int IDENTITY(1,1) NOT NULL,
    [IdUser] int  NOT NULL,
    [IdFilm] int  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ords'
CREATE TABLE [dbo].[Ords] (
    [IdOrder] int IDENTITY(1,1) NOT NULL,
    [IdUser] int  NOT NULL,
    [IdFilm] int  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdFilm] in table 'Films1'
ALTER TABLE [dbo].[Films1]
ADD CONSTRAINT [PK_Films1]
    PRIMARY KEY CLUSTERED ([IdFilm] ASC);
GO

-- Creating primary key on [IdUser] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([IdUser] ASC);
GO

-- Creating primary key on [IdOrder] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([IdOrder] ASC);
GO

-- Creating primary key on [IdOrder] in table 'Ords'
ALTER TABLE [dbo].[Ords]
ADD CONSTRAINT [PK_Ords]
    PRIMARY KEY CLUSTERED ([IdOrder] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------