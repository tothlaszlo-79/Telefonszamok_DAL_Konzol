
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/07/2018 12:52:14
-- Generated from EDMX file: D:\Suli\WPF\Telefonszamok_DAL_Konzol\Telefonszamok_DAL_Konzol\edmTelefonszamok.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Telefonszamok];
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

-- Creating table 'enSzemelyek'
CREATE TABLE [dbo].[enSzemelyek] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Vezeteknev] nvarchar(max)  NOT NULL,
    [Utonev] nvarchar(max)  NOT NULL,
    [Lakcim] nvarchar(max)  NOT NULL,
    [enHelyseg_Id] int  NOT NULL
);
GO

-- Creating table 'enTelefonszamSet'
CREATE TABLE [dbo].[enTelefonszamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Szam] nvarchar(max)  NOT NULL,
    [enSzemely_Id] int  NOT NULL
);
GO

-- Creating table 'enHelysegSet'
CREATE TABLE [dbo].[enHelysegSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Irsz] smallint  NOT NULL,
    [Nev] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'enSzemelyek'
ALTER TABLE [dbo].[enSzemelyek]
ADD CONSTRAINT [PK_enSzemelyek]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'enTelefonszamSet'
ALTER TABLE [dbo].[enTelefonszamSet]
ADD CONSTRAINT [PK_enTelefonszamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'enHelysegSet'
ALTER TABLE [dbo].[enHelysegSet]
ADD CONSTRAINT [PK_enHelysegSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [enSzemely_Id] in table 'enTelefonszamSet'
ALTER TABLE [dbo].[enTelefonszamSet]
ADD CONSTRAINT [FK_enSzemelyenTelefonszam]
    FOREIGN KEY ([enSzemely_Id])
    REFERENCES [dbo].[enSzemelyek]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_enSzemelyenTelefonszam'
CREATE INDEX [IX_FK_enSzemelyenTelefonszam]
ON [dbo].[enTelefonszamSet]
    ([enSzemely_Id]);
GO

-- Creating foreign key on [enHelyseg_Id] in table 'enSzemelyek'
ALTER TABLE [dbo].[enSzemelyek]
ADD CONSTRAINT [FK_enHelysegenSzemely]
    FOREIGN KEY ([enHelyseg_Id])
    REFERENCES [dbo].[enHelysegSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_enHelysegenSzemely'
CREATE INDEX [IX_FK_enHelysegenSzemely]
ON [dbo].[enSzemelyek]
    ([enHelyseg_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------