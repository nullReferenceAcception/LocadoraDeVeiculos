CREATE TABLE [dbo].[tb_cliente] (
    [guid_cliente]      UNIQUEIDENTIFIER CONSTRAINT [DF_tb_cliente_id_cliente] DEFAULT (newid()) NOT NULL,
    [nome]              VARCHAR (MAX)    NOT NULL,
    [endereco]          VARCHAR (MAX)    NOT NULL,
    [cnh]               CHAR (11)        NOT NULL,
    [email]             VARCHAR (MAX)    NOT NULL,
    [telefone]          VARCHAR (MAX)    NOT NULL,
    [tipo_cliente]      BIT              NOT NULL,
    [cpf]               CHAR (11)        NULL,
    [cnpj]              CHAR (14)        NULL,
    [data_validade_cnh] DATE             NULL,
    CONSTRAINT [PK_tb_cliente] PRIMARY KEY CLUSTERED ([guid_cliente] ASC)
);

