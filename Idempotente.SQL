IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220312020231_SegundaMigracao')
BEGIN
    CREATE TABLE [Cursos] (
        [Id] int NOT NULL IDENTITY,
        [Titulo] VARCHAR(20) NOT NULL,
        [Duracao] INT NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Cursos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220312020231_SegundaMigracao')
BEGIN
    CREATE TABLE [Usuario] (
        [Id] int NOT NULL IDENTITY,
        [Name] VARCHAR(100) NOT NULL,
        [Email] VARCHAR(100) NOT NULL,
        [Password] nvarchar(20) NOT NULL,
        [Role] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220312020231_SegundaMigracao')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220312020231_SegundaMigracao', N'5.0.15');
END;
GO

COMMIT;
GO

