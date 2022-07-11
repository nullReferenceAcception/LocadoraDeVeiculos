CREATE TABLE [dbo].[tb_funcionario] (
    [guid_funcionario] UNIQUEIDENTIFIER CONSTRAINT [DF_tb_funcionario_guid_funcionario] DEFAULT (newid()) NOT NULL,
    [nome]             VARCHAR (MAX)    NOT NULL,
    [login]            VARCHAR (MAX)    NOT NULL,
    [senha]            VARCHAR (MAX)    NOT NULL,
    [telefone]         VARCHAR (MAX)    NOT NULL,
    [endereco]         VARCHAR (MAX)    NOT NULL,
    [email]            VARCHAR (MAX)    CONSTRAINT [DF_tb_funcionario_email] DEFAULT (NULL) NOT NULL,
    [cidade]           VARCHAR (MAX)    NOT NULL,
    [salario]          DECIMAL (11, 2)  NOT NULL,
    [data_admissao]    DATE             NOT NULL,
    [eh_admin]         BIT              NOT NULL,
    [esta_ativo]       BIT              NOT NULL,
    CONSTRAINT [PK_tb_funcionario] PRIMARY KEY CLUSTERED ([guid_funcionario] ASC)
);

