CREATE TABLE [dbo].[tb_veiculo] (
    [id_veiculo]          INT             IDENTITY (1, 1) NOT NULL,
    [modelo]              VARCHAR (MAX)   NOT NULL,
    [placa]               CHAR (7)        NOT NULL,
    [marca]               VARCHAR (MAX)   NOT NULL,
    [ano]                 INT             NOT NULL,
    [capacidade_tanque]   DECIMAL (11, 2) NOT NULL,
    [km_percorrido]       DECIMAL (11, 2) NOT NULL,
    [cor]                 VARCHAR (MAX)   NOT NULL,
    [combustivel]         VARCHAR (MAX)   NOT NULL,
    [grupo_de_veiculo_id] INT             NOT NULL,
    [foto]                VARBINARY (MAX) NOT NULL,
    CONSTRAINT [PK_tb_veiculo] PRIMARY KEY CLUSTERED ([id_veiculo] ASC),
    CONSTRAINT [FK_tb_veiculo_tb_grupo_veiculo] FOREIGN KEY ([grupo_de_veiculo_id]) REFERENCES [dbo].[tb_grupo_veiculo] ([id_grupo_veiculo])
);