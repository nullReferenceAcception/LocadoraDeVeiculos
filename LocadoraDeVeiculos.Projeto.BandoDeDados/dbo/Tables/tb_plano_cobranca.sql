CREATE TABLE [dbo].[tb_plano_cobranca] (
    [id_plano_cobranca] INT             IDENTITY (1, 1) NOT NULL,
    [nome]              VARCHAR (MAX)   NOT NULL,
    [km_livre_incluso ] INT             NOT NULL,
    [valor_dia ]        DECIMAL (11, 2) NOT NULL,
    [valor_por_km ]     DECIMAL (11, 2) NOT NULL,
    [grupo_veiculo_id]  INT             NOT NULL,
    [plano]             VARCHAR (MAX)   NOT NULL,
    PRIMARY KEY CLUSTERED ([id_plano_cobranca] ASC),
    CONSTRAINT [FK_plano_cobranca_To_grupo_veiculo] FOREIGN KEY ([grupo_veiculo_id]) REFERENCES [dbo].[tb_grupo_veiculo] ([id_grupo_veiculo])
);

