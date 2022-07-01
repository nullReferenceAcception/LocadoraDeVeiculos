CREATE TABLE [dbo].[tb_condutor] (
    [Id_condutor]       INT           IDENTITY (1, 1) NOT NULL,
    [nome]              VARCHAR (100) NOT NULL,
    [endereco]          VARCHAR (100) NOT NULL,
    [cnh]               CHAR (11)     NOT NULL,
    [email]             VARCHAR (100) NOT NULL,
    [telefone]          CHAR (11)     NOT NULL,
    [cpf]               CHAR (11)     NOT NULL,
    [cliente_id]        INT           NOT NULL,
    [data_validade_cnh] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_condutor] ASC),
    CONSTRAINT [FK_tb_condutor_ToTable] FOREIGN KEY ([cliente_id]) REFERENCES [dbo].[tb_cliente] ([id_cliente])
);

