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
CREATE TABLE [Products] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251117132718_InitialCreate', N'9.0.11');

ALTER TABLE [Products] ADD [CategoryId] uniqueidentifier NULL;

CREATE TABLE [Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);

CREATE INDEX [IX_Products_Price] ON [Products] ([Price]);

ALTER TABLE [Products] ADD CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE SET NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251117133523_AddCategory', N'9.0.11');

COMMIT;
GO

