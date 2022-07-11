CREATE TABLE [dbo].[tb_veiculo] (
    [guid_veiculo]       UNIQUEIDENTIFIER CONSTRAINT [DF_tb_veiculo_guid_veiculo] DEFAULT (newid()) NOT NULL,
    [modelo]             VARCHAR (MAX)    NOT NULL,
    [placa]              CHAR (7)         NOT NULL,
    [ano]                INT              NOT NULL,
    [marca]              VARCHAR (MAX)    NOT NULL,
    [cor]                VARCHAR (MAX)    NOT NULL,
    [combustivel]        VARCHAR (MAX)    NOT NULL,
    [km_percorrido]      DECIMAL (11, 2)  NOT NULL,
    [capacidade_tanque]  DECIMAL (11, 2)  NOT NULL,
    [foto]               VARBINARY (MAX)  NOT NULL,
    [grupo_veiculo_guid] UNIQUEIDENTIFIER CONSTRAINT [DF_tb_veiculo_grupo_veiculo_guid] DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_tb_veiculo_1] PRIMARY KEY CLUSTERED ([guid_veiculo] ASC)
);

