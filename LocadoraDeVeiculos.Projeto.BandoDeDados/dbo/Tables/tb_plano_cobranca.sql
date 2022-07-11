CREATE TABLE [dbo].[tb_plano_cobranca] (
    [guid_plano_cobranca] UNIQUEIDENTIFIER CONSTRAINT [DF_tb_plano_cobranca_guid_plano_cobranca] DEFAULT (newid()) NOT NULL,
    [nome]                VARCHAR (MAX)    NOT NULL,
    [km_livre_incluso]    INT              NOT NULL,
    [valor_dia]           DECIMAL (11, 2)  NOT NULL,
    [valor_por_km]        DECIMAL (11, 2)  NOT NULL,
    [plano]               VARCHAR (MAX)    NOT NULL,
    [grupo_veiculo_guid]  UNIQUEIDENTIFIER CONSTRAINT [DF_tb_plano_cobranca_grupo_veiculo_guid] DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_tb_plano_cobranca] PRIMARY KEY CLUSTERED ([guid_plano_cobranca] ASC),
    CONSTRAINT [FK_tb_plano_cobranca_tb_grupo_veiculo] FOREIGN KEY ([grupo_veiculo_guid]) REFERENCES [dbo].[tb_grupo_veiculo] ([guid_grupo_veiculo])
);

