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

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] VARCHAR(80) NOT NULL,
    [Telephone] CHAR(11) NOT NULL,
    [Cep] CHAR(8) NOT NULL,
    [State] CHAR(2) NOT NULL,
    [City] nvarchar(60) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [BarCode] VARCHAR(14) NOT NULL,
    [Description] VARCHAR(60) NULL,
    [Value] decimal(18,2) NOT NULL,
    [TypeProduct] nvarchar(30) NOT NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Solicitations] (
    [Id] int NOT NULL IDENTITY,
    [ClientId] int NOT NULL,
    [StartDate] datetime2 NOT NULL DEFAULT (GETDATE()),
    [EndDate] datetime2 NOT NULL,
    [TypeShipping] int NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    [Observation] VARCHAR(512) NULL,
    CONSTRAINT [PK_Solicitations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Solicitations_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [SolicitationItems] (
    [Id] int NOT NULL IDENTITY,
    [SolicitationId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Quantity] int NOT NULL DEFAULT 1,
    [Value] decimal(18,2) NOT NULL,
    [Discount] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_SolicitationItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SolicitationItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SolicitationItems_Solicitations_SolicitationId] FOREIGN KEY ([SolicitationId]) REFERENCES [Solicitations] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [idx_client_telephone] ON [Clients] ([Telephone]);
GO

CREATE INDEX [IX_SolicitationItems_ProductId] ON [SolicitationItems] ([ProductId]);
GO

CREATE INDEX [IX_SolicitationItems_SolicitationId] ON [SolicitationItems] ([SolicitationId]);
GO

CREATE INDEX [IX_Solicitations_ClientId] ON [Solicitations] ([ClientId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220916155312_InitialMigration', N'6.0.9');
GO

COMMIT;
GO

