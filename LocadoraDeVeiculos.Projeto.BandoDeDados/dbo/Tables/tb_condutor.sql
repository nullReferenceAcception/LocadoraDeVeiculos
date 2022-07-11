CREATE TABLE [dbo].[tb_condutor] (
    [guid_condutor]     UNIQUEIDENTIFIER CONSTRAINT [DF_tb_condutor_id_condutor] DEFAULT (newid()) NOT NULL,
    [nome]              VARCHAR (100)    NOT NULL,
    [endereco]          VARCHAR (100)    NOT NULL,
    [cnh]               CHAR (11)        NOT NULL,
    [email]             VARCHAR (100)    NOT NULL,
    [telefone]          CHAR (11)        NOT NULL,
    [cpf]               CHAR (11)        NOT NULL,
    [data_validade_cnh] DATE             NOT NULL,
    [cliente_guid]      UNIQUEIDENTIFIER CONSTRAINT [DF_tb_condutor_cliente_guid] DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_tb_condutor] PRIMARY KEY CLUSTERED ([guid_condutor] ASC),
    CONSTRAINT [FK_tb_condutor_tb_cliente] FOREIGN KEY ([cliente_guid]) REFERENCES [dbo].[tb_cliente] ([guid_cliente])
);

