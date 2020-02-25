
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2020 07:15:32
-- Generated from EDMX file: D:\Koulukansio\TietokantasovellusJaVisualStudio\WebApp\AspNetTilausDB\AspNetTilausDB\TilausDBEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [kalakauppa];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Henkilot__Esimie__5BE2A6F2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Henkilot] DROP CONSTRAINT [FK__Henkilot__Esimie__5BE2A6F2];
GO
IF OBJECT_ID(N'[dbo].[FK__Henkilot__Postin__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Henkilot] DROP CONSTRAINT [FK__Henkilot__Postin__5CD6CB2B];
GO
IF OBJECT_ID(N'[dbo].[FK__Shippers__Postin__5DCAEF64]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Shippers] DROP CONSTRAINT [FK__Shippers__Postin__5DCAEF64];
GO
IF OBJECT_ID(N'[dbo].[FK__Tuotteet__Alkupe__628FA481]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tuotteet] DROP CONSTRAINT [FK__Tuotteet__Alkupe__628FA481];
GO
IF OBJECT_ID(N'[dbo].[FK_Asiakkaat_Postitoimipaikat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Asiakkaat] DROP CONSTRAINT [FK_Asiakkaat_Postitoimipaikat];
GO
IF OBJECT_ID(N'[dbo].[FK_Tilaukset_Asiakkaat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tilaukset] DROP CONSTRAINT [FK_Tilaukset_Asiakkaat];
GO
IF OBJECT_ID(N'[dbo].[FK_Tilaukset_Postitoimipaikat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tilaukset] DROP CONSTRAINT [FK_Tilaukset_Postitoimipaikat];
GO
IF OBJECT_ID(N'[dbo].[FK_Tilausrivit_Tilaukset]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tilausrivit] DROP CONSTRAINT [FK_Tilausrivit_Tilaukset];
GO
IF OBJECT_ID(N'[dbo].[FK_Tilausrivit_Tuotteet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tilausrivit] DROP CONSTRAINT [FK_Tilausrivit_Tuotteet];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Asiakkaat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Asiakkaat];
GO
IF OBJECT_ID(N'[dbo].[Esimiehet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Esimiehet];
GO
IF OBJECT_ID(N'[dbo].[Henkilot]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Henkilot];
GO
IF OBJECT_ID(N'[dbo].[Logins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logins];
GO
IF OBJECT_ID(N'[dbo].[Postitoimipaikat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Postitoimipaikat];
GO
IF OBJECT_ID(N'[dbo].[Regions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Regions];
GO
IF OBJECT_ID(N'[dbo].[Shippers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shippers];
GO
IF OBJECT_ID(N'[dbo].[Tilaukset]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tilaukset];
GO
IF OBJECT_ID(N'[dbo].[Tilausrivit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tilausrivit];
GO
IF OBJECT_ID(N'[dbo].[Tuotteet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tuotteet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Asiakkaats'
CREATE TABLE [dbo].[Asiakkaats] (
    [AsiakasID] int IDENTITY(1,1) NOT NULL,
    [Nimi] varchar(50)  NULL,
    [Osoite] varchar(50)  NULL,
    [Postinumero] char(5)  NULL
);
GO

-- Creating table 'Henkilots'
CREATE TABLE [dbo].[Henkilots] (
    [Henkilo_id] int IDENTITY(1,1) NOT NULL,
    [Etunimi] nvarchar(50)  NULL,
    [Sukunimi] nvarchar(50)  NULL,
    [Osoite] nvarchar(100)  NULL,
    [Esimies] int  NULL,
    [Sahkoposti] nvarchar(100)  NULL,
    [Postinumero] char(5)  NULL
);
GO

-- Creating table 'Postitoimipaikats'
CREATE TABLE [dbo].[Postitoimipaikats] (
    [Postinumero] char(5)  NOT NULL,
    [Postitoimipaikka] varchar(50)  NULL
);
GO

-- Creating table 'Shippers'
CREATE TABLE [dbo].[Shippers] (
    [ShipperID] int  NOT NULL,
    [Nimi] nvarchar(100)  NULL,
    [Osoite] nvarchar(100)  NULL,
    [Postinumero] char(5)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Tilauksets'
CREATE TABLE [dbo].[Tilauksets] (
    [TilausID] int IDENTITY(1,1) NOT NULL,
    [AsiakasID] int  NULL,
    [Toimitusosoite] varchar(100)  NULL,
    [Postinumero] char(5)  NULL,
    [Tilauspvm] datetime  NULL,
    [Toimituspvm] datetime  NULL
);
GO

-- Creating table 'Tilausrivits'
CREATE TABLE [dbo].[Tilausrivits] (
    [TilausriviID] int IDENTITY(1,1) NOT NULL,
    [TilausID] int  NULL,
    [TuoteID] int  NULL,
    [Maara] int  NULL,
    [Ahinta] decimal(5,2)  NULL
);
GO

-- Creating table 'Tuotteets'
CREATE TABLE [dbo].[Tuotteets] (
    [TuoteID] int IDENTITY(1,1) NOT NULL,
    [Nimi] varchar(50)  NULL,
    [Ahinta] decimal(7,2)  NULL,
    [ImageLink] varchar(200)  NULL,
    [VarastoSaldo] smallint  NULL,
    [AlkuperaMaa] varchar(2)  NULL
);
GO

-- Creating table 'Esimiehets'
CREATE TABLE [dbo].[Esimiehets] (
    [EsimiesID] int  NOT NULL,
    [Etunimi] nvarchar(50)  NULL,
    [Sukunimi] nvarchar(50)  NULL,
    [Titteli] nvarchar(50)  NULL
);
GO

-- Creating table 'Regions'
CREATE TABLE [dbo].[Regions] (
    [RegionID] int IDENTITY(1,1) NOT NULL,
    [RegionShort] varchar(2)  NOT NULL,
    [RegionLong] varchar(50)  NULL
);
GO

-- Creating table 'Logins'
CREATE TABLE [dbo].[Logins] (
    [LoginId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [PassWord] nvarchar(50)  NOT NULL,
    [ryhma] nvarchar(15)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AsiakasID] in table 'Asiakkaats'
ALTER TABLE [dbo].[Asiakkaats]
ADD CONSTRAINT [PK_Asiakkaats]
    PRIMARY KEY CLUSTERED ([AsiakasID] ASC);
GO

-- Creating primary key on [Henkilo_id] in table 'Henkilots'
ALTER TABLE [dbo].[Henkilots]
ADD CONSTRAINT [PK_Henkilots]
    PRIMARY KEY CLUSTERED ([Henkilo_id] ASC);
GO

-- Creating primary key on [Postinumero] in table 'Postitoimipaikats'
ALTER TABLE [dbo].[Postitoimipaikats]
ADD CONSTRAINT [PK_Postitoimipaikats]
    PRIMARY KEY CLUSTERED ([Postinumero] ASC);
GO

-- Creating primary key on [ShipperID] in table 'Shippers'
ALTER TABLE [dbo].[Shippers]
ADD CONSTRAINT [PK_Shippers]
    PRIMARY KEY CLUSTERED ([ShipperID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TilausID] in table 'Tilauksets'
ALTER TABLE [dbo].[Tilauksets]
ADD CONSTRAINT [PK_Tilauksets]
    PRIMARY KEY CLUSTERED ([TilausID] ASC);
GO

-- Creating primary key on [TilausriviID] in table 'Tilausrivits'
ALTER TABLE [dbo].[Tilausrivits]
ADD CONSTRAINT [PK_Tilausrivits]
    PRIMARY KEY CLUSTERED ([TilausriviID] ASC);
GO

-- Creating primary key on [TuoteID] in table 'Tuotteets'
ALTER TABLE [dbo].[Tuotteets]
ADD CONSTRAINT [PK_Tuotteets]
    PRIMARY KEY CLUSTERED ([TuoteID] ASC);
GO

-- Creating primary key on [EsimiesID] in table 'Esimiehets'
ALTER TABLE [dbo].[Esimiehets]
ADD CONSTRAINT [PK_Esimiehets]
    PRIMARY KEY CLUSTERED ([EsimiesID] ASC);
GO

-- Creating primary key on [RegionShort] in table 'Regions'
ALTER TABLE [dbo].[Regions]
ADD CONSTRAINT [PK_Regions]
    PRIMARY KEY CLUSTERED ([RegionShort] ASC);
GO

-- Creating primary key on [LoginId] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [PK_Logins]
    PRIMARY KEY CLUSTERED ([LoginId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Postinumero] in table 'Asiakkaats'
ALTER TABLE [dbo].[Asiakkaats]
ADD CONSTRAINT [FK_Asiakkaat_Postitoimipaikat]
    FOREIGN KEY ([Postinumero])
    REFERENCES [dbo].[Postitoimipaikats]
        ([Postinumero])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Asiakkaat_Postitoimipaikat'
CREATE INDEX [IX_FK_Asiakkaat_Postitoimipaikat]
ON [dbo].[Asiakkaats]
    ([Postinumero]);
GO

-- Creating foreign key on [AsiakasID] in table 'Tilauksets'
ALTER TABLE [dbo].[Tilauksets]
ADD CONSTRAINT [FK_Tilaukset_Asiakkaat]
    FOREIGN KEY ([AsiakasID])
    REFERENCES [dbo].[Asiakkaats]
        ([AsiakasID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tilaukset_Asiakkaat'
CREATE INDEX [IX_FK_Tilaukset_Asiakkaat]
ON [dbo].[Tilauksets]
    ([AsiakasID]);
GO

-- Creating foreign key on [Postinumero] in table 'Henkilots'
ALTER TABLE [dbo].[Henkilots]
ADD CONSTRAINT [FK__Henkilot__Postin__5BE2A6F2]
    FOREIGN KEY ([Postinumero])
    REFERENCES [dbo].[Postitoimipaikats]
        ([Postinumero])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Henkilot__Postin__5BE2A6F2'
CREATE INDEX [IX_FK__Henkilot__Postin__5BE2A6F2]
ON [dbo].[Henkilots]
    ([Postinumero]);
GO

-- Creating foreign key on [Postinumero] in table 'Tilauksets'
ALTER TABLE [dbo].[Tilauksets]
ADD CONSTRAINT [FK_Tilaukset_Postitoimipaikat]
    FOREIGN KEY ([Postinumero])
    REFERENCES [dbo].[Postitoimipaikats]
        ([Postinumero])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tilaukset_Postitoimipaikat'
CREATE INDEX [IX_FK_Tilaukset_Postitoimipaikat]
ON [dbo].[Tilauksets]
    ([Postinumero]);
GO

-- Creating foreign key on [TilausID] in table 'Tilausrivits'
ALTER TABLE [dbo].[Tilausrivits]
ADD CONSTRAINT [FK_Tilausrivit_Tilaukset]
    FOREIGN KEY ([TilausID])
    REFERENCES [dbo].[Tilauksets]
        ([TilausID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tilausrivit_Tilaukset'
CREATE INDEX [IX_FK_Tilausrivit_Tilaukset]
ON [dbo].[Tilausrivits]
    ([TilausID]);
GO

-- Creating foreign key on [TuoteID] in table 'Tilausrivits'
ALTER TABLE [dbo].[Tilausrivits]
ADD CONSTRAINT [FK_Tilausrivit_Tuotteet]
    FOREIGN KEY ([TuoteID])
    REFERENCES [dbo].[Tuotteets]
        ([TuoteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tilausrivit_Tuotteet'
CREATE INDEX [IX_FK_Tilausrivit_Tuotteet]
ON [dbo].[Tilausrivits]
    ([TuoteID]);
GO

-- Creating foreign key on [Esimies] in table 'Henkilots'
ALTER TABLE [dbo].[Henkilots]
ADD CONSTRAINT [FK__Henkilot__Esimie__70DDC3D8]
    FOREIGN KEY ([Esimies])
    REFERENCES [dbo].[Esimiehets]
        ([EsimiesID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Henkilot__Esimie__70DDC3D8'
CREATE INDEX [IX_FK__Henkilot__Esimie__70DDC3D8]
ON [dbo].[Henkilots]
    ([Esimies]);
GO

-- Creating foreign key on [Postinumero] in table 'Shippers'
ALTER TABLE [dbo].[Shippers]
ADD CONSTRAINT [FK__Shippers__Postin__74AE54BC]
    FOREIGN KEY ([Postinumero])
    REFERENCES [dbo].[Postitoimipaikats]
        ([Postinumero])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Shippers__Postin__74AE54BC'
CREATE INDEX [IX_FK__Shippers__Postin__74AE54BC]
ON [dbo].[Shippers]
    ([Postinumero]);
GO

-- Creating foreign key on [AlkuperaMaa] in table 'Tuotteets'
ALTER TABLE [dbo].[Tuotteets]
ADD CONSTRAINT [FK__Tuotteet__Alkupe__7F2BE32F]
    FOREIGN KEY ([AlkuperaMaa])
    REFERENCES [dbo].[Regions]
        ([RegionShort])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tuotteet__Alkupe__7F2BE32F'
CREATE INDEX [IX_FK__Tuotteet__Alkupe__7F2BE32F]
ON [dbo].[Tuotteets]
    ([AlkuperaMaa]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------