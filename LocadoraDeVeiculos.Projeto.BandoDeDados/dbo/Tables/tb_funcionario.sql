CREATE TABLE [dbo].[tb_funcionario] (
    [id_funcionario] INT             IDENTITY (1, 1) NOT NULL,
    [nome]           VARCHAR (MAX)   NOT NULL,
    [salario]        DECIMAL (11, 2) NOT NULL,
    [data_admissao]  DATE            NOT NULL,
    [login]          VARCHAR (MAX)   NOT NULL,
    [senha]          VARCHAR (MAX)   NOT NULL,
    [eh_admin]       BIT             NOT NULL,
    [telefone]       VARCHAR (MAX)   NOT NULL,
    [endereco]       VARCHAR (MAX)   NOT NULL,
    [email]          VARCHAR (MAX)   CONSTRAINT [DF_tb_funcionario_email] DEFAULT (NULL) NOT NULL,
    [cidade]         VARCHAR (MAX)   NOT NULL,
    [esta_ativo]     BIT             NOT NULL,
    CONSTRAINT [PK__tb_funci__6FBD69C4ACADEDC5] PRIMARY KEY CLUSTERED ([id_funcionario] ASC)
);

