﻿CREATE TABLE [dbo].[tb_cliente] (
    [id_cliente]   INT           IDENTITY (1, 1) NOT NULL,
    [nome]         VARCHAR (MAX) NOT NULL,
    [endereco]     VARCHAR (MAX) NOT NULL,
    [cnh]          CHAR (11)     NOT NULL,
    [email]        VARCHAR (MAX) NOT NULL,
    [telefone]     VARCHAR (MAX) NOT NULL,
    [tipo_cliente] BIT           NOT NULL,
    [cpf]          CHAR (11)     NOT NULL,
    [cnpj]         CHAR (14)     NOT NULL,
    CONSTRAINT [PK__Table__677F38F5C26098D1] PRIMARY KEY CLUSTERED ([id_cliente] ASC)
);
