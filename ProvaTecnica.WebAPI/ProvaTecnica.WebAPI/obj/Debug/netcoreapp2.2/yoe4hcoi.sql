IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Escolas] (
    [IdEscola] int NOT NULL IDENTITY,
    [NomeEscola] nvarchar(max) NULL,
    CONSTRAINT [PK_Escolas] PRIMARY KEY ([IdEscola])
);

GO

CREATE TABLE [Perfil] (
    [IdPerfil] int NOT NULL IDENTITY,
    [TipoPerfil] nvarchar(max) NULL,
    CONSTRAINT [PK_Perfil] PRIMARY KEY ([IdPerfil])
);

GO

CREATE TABLE [Turmas] (
    [IdTurma] int NOT NULL IDENTITY,
    [NomeTurma] nvarchar(max) NULL,
    [IdEscola] int NOT NULL,
    CONSTRAINT [PK_Turmas] PRIMARY KEY ([IdTurma]),
    CONSTRAINT [FK_Turmas_Escolas_IdEscola] FOREIGN KEY ([IdEscola]) REFERENCES [Escolas] ([IdEscola]) ON DELETE CASCADE
);

GO

CREATE TABLE [Usuarios] (
    [IdUsuario] int NOT NULL IDENTITY,
    [NomeUsuario] nvarchar(max) NULL,
    [IdPerfil] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([IdUsuario]),
    CONSTRAINT [FK_Usuarios_Perfil_IdPerfil] FOREIGN KEY ([IdPerfil]) REFERENCES [Perfil] ([IdPerfil]) ON DELETE CASCADE
);

GO

CREATE TABLE [Alunos] (
    [IdAluno] int NOT NULL IDENTITY,
    [NomeAluno] nvarchar(max) NULL,
    [NotaAluno] decimal(18,2) NOT NULL,
    [IdTurma] int NOT NULL,
    CONSTRAINT [PK_Alunos] PRIMARY KEY ([IdAluno]),
    CONSTRAINT [FK_Alunos_Turmas_IdTurma] FOREIGN KEY ([IdTurma]) REFERENCES [Turmas] ([IdTurma]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Alunos_IdTurma] ON [Alunos] ([IdTurma]);

GO

CREATE INDEX [IX_Turmas_IdEscola] ON [Turmas] ([IdEscola]);

GO

CREATE INDEX [IX_Usuarios_IdPerfil] ON [Usuarios] ([IdPerfil]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210203004906_Initial', N'2.2.6-servicing-10079');

GO

